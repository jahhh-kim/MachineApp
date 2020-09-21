using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    /// <summary>
    /// [2]Model Class : Machine 모델 클래스 == Machines 테이블과 일대일로 매핑 Machie , MachineModel , MachineBase 
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// Serial Numder
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// HardWare Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

    }
    /// <summary>
    /// [3] Repository Interface
    /// Add Get Update Remove
    /// </summary>
    public interface IMachineRepository
    {
        Task<Machine> AddMachineAsync(Machine machine); //입력
        Task<List<Machine>> GetMachinesAsync(); //출력
        Task<Machine> GetMachineByIdAsync(int id); //상세 GetById(), FindById()
        Task<Machine> EditMachineAsync(Machine machine); //수정
        Task DeleteMachine(int id); //삭제 
    }
    /// <summary>
    /// [4] DcContext Class
    /// </summary>
    public class MachineDbContext : DbContext // DbContext 상속하기
    {
        //Install - Microsoft.EntityFrameworkCore.SqlServer;
        //Install - Microsoft.EntityFrameworkCore.InMemory;
        //Install - System.Configuration.ConfigurationManager

        public MachineDbContext()
        {
            //Empty
        }

        public MachineDbContext(DbContextOptions<MachineDbContext> options)
            :base(options)
        {
            //공식과 같은 코드
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역: 
            // App.config 또는 Web.config의 연결 문자열 사용
            // 커넥션 스트링 읽기 위한 메소드
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Machines 테이블의 Created 열은 자동으로 GetDate() 제약 조건을 부여하기
            modelBuilder.Entity<Machine>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }
        // 이까지는 거의 공식

        /// <summary>
        ///MachineApp에 접근하고 싶다
        /// </summary>
        public DbSet<Machine> Machines { get; set; }

    }


    /// <summary>
    /// [5] Repository Class
    /// </summary>
    public class MachineRepository : IMachineRepository
    {
        private readonly MachineDbContext _context;

        //생성자의 메게변수 주입방식으로 디비컨테슥트 클래스 주입!!
        public MachineRepository(MachineDbContext context)
        {
            this._context = context;
        }
        //입력
        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            await _context.AddAsync<Machine>(machine);
            await _context.SaveChangesAsync();
            return machine;
        }
        //출력
        public async Task<List<Machine>> GetMachinesAsync()
        {
           return await _context.Machines.OrderByDescending(m=>m.Id).ToListAsync();
        }
        //상세보기
        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            return await _context.Machines.Where(m => m.Id == id).SingleOrDefaultAsync();
        }
        //수정
        public async Task<Machine> EditMachineAsync(Machine machine)
        {
            _context.Entry<Machine>(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return machine;

        }
        //삭제
        public async Task DeleteMachine(int id)
        {
            var machine = await  _context.Machines.Where(m => m.Id == id).SingleOrDefaultAsync();
            if (machine != null)
            {
                _context.Machines.Remove(machine);
                await _context.SaveChangesAsync();
            }
        }
    }
}

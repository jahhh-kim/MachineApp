using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MachineApp.Models
{
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

        public MachineDbContext(DbContextOptions<MachineDbContext>options)
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
            modelBuilder.Entity<Media>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<MachineMedia>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }
        // 이까지는 거의 공식

        /// <summary>
        ///MachineApp에 접근하고 싶다
        /// </summary>
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MachineMedia> MachinesMedias { get; set; }
    }
}

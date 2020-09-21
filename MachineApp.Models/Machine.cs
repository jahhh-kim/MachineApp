using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int id { get; set; }

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
        Task<Machine> AddMachineAsync(); //입력
        Task<List<Machine>> GetMachinesAsync(); //출력
        Task<Machine> GetMachineByIdAsync(); //상세 GetById(), FindById()
        Task<Machine> EditMachineAsync(Machine machine); //수정
        Task DeleteMachine(int id); //삭제 
    }

    /// <summary>
    /// [4] Repository Class
    /// </summary>
    public class MachineRepository : IMachineRepository
    {
        public Task<Machine> AddMachineAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Machine>> GetMachinesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Machine> GetMachineByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Machine> EditMachineAsync(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMachine(int id)
        {
            throw new NotImplementedException();
        }

      
      

     
    }
    /// <summary>
    /// [5] DcContext Class
    /// </summary>
    public class MachineDbContext
    {

    }
}

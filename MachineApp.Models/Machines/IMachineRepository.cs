using MachineApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineApp.Models
{
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

        Task<PagingResult<Machine>> GetMachinesPageAsync(int pageIndex, int pageSize); //출력 : 페이징이 처리된
    }
}

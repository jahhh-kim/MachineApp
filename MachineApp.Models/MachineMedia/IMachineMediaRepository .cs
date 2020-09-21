using MachineApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    /// <summary>
    /// [3] Repository Interface
    /// Add Get Update Remove
    /// </summary>
    public interface IMachineMediaRepository
    {
        Task AddMachineMediaAsync(int machineId, int media); //입력
        Task<Media> GetMediasByMachineIdAsync(int machineId); //출력
        Task<Machine> GetMachineByMedaiIdAsync(int mediaId); //출력
        Task DeleteMedia(int machineId, int media); //삭제 
    }
}

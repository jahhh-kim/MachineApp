using MachineApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    /// <summary>
    /// [3] Repository Interface
    /// Add Get Update Remove
    /// </summary>
    public interface IMediaRepository
    {
        Task<Media> AddMediaAsync(Media media); //입력
        Task<List<Media>> GetMediaAsync(); //출력
        Task<Media> GetMediaByIdAsync(int id); //상세 GetById(), FindById()
        Task<Media> EditMediaAsync(Media media); //수정
        Task DeleteMedia(int id); //삭제 

        Task<PagingResult<Media>> GetMediaPageAsync(int pageIndex, int pageSize); //출력 : 페이징이 처리된
    }
}

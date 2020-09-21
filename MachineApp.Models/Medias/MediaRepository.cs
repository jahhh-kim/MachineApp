using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    /// <summary>
    /// [5] Repository Class
    /// </summary>
    public class MediaRepository : IMediaRepository
    {
        private readonly MachineDbContext _context;

        //생성자의 메게변수 주입방식으로 디비컨테슥트 클래스 주입!!
        public MediaRepository(MachineDbContext context)
        {
            this._context = context;
        }
        //입력
        public async Task<Media> AddMediaAsync(Media media)
        {
            await _context.AddAsync<Media>(media);
            await _context.SaveChangesAsync();
            return media;
        }
        //출력
        public async Task<List<Media>> GetMediaAsync()
        {
           return await _context.Medias.OrderByDescending(m=>m.Id).ToListAsync();
        }
        //상세보기
        public async Task<Media> GetMediaByIdAsync(int id)
        {
            return await _context.Medias.Where(m => m.Id == id).SingleOrDefaultAsync();
        }
        //수정
        public async Task<Media> EditMediaAsync(Media media)
        {
            _context.Entry<Media>(media).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return media;

        }
        //삭제
        public async Task DeleteMedia(int id)
        {
            var media = await  _context.Medias.Where(m => m.Id == id).SingleOrDefaultAsync();
            if (media != null)
            {
                _context.Medias.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
        //[!] Index + Paging

        public async Task<PagingResult<Media>> GetMediaPageAsync(int pageIndex, int pageSize)
        {
            var totalRecords = await _context.Medias.CountAsync();
            var medias = await _context.Medias
                .OrderByDescending(m => m.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagingResult<Media>(medias, totalRecords);
        }
    }
}

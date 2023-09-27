using ChronoScholar.Service.Dto.TextbookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Interfaces.Textbook
{
    public interface ITextbookService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<TextbookForResultDto>> GetAllAsync();
        public Task<TextbookForResultDto> GetByIdAsync(long id);
        public Task<TextbookForResultDto> UpdateAsync(TextbookForUpdateDto dto);
        public Task<TextbookForResultDto> CreateAsync(TextbookForCreationDto dto);
    }
}

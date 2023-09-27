using ChronoScholar.Service.Dto.SellerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Interfaces.Seller
{
    public interface ISellerService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<SellerForResultDto>> GetAllAsync();
        public Task<SellerForResultDto> GetByIdAsync(long id);
        public Task<SellerForResultDto> UpdateAsync(SellerForUpdateDto dto);
        public Task<SellerForResultDto> CreateAsync(SellerForCreationDto dto);
    }
}

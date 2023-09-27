using ChronoScholar.Data.IRepositories;
using ChronoScholar.Data.Repositories;
using ChronoScholar.Domain.Entities;
using ChronoScholar.Service.Dto.SellerDto;
using ChronoScholar.Service.Exceptions;
using ChronoScholar.Service.Interfaces.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Services
{
    public class SellerService:ISellerService
    {
        private readonly IRepository<Seller> repository = new Repository<Seller>();
        private long _id;
        public async Task<SellerForResultDto> CreateAsync(SellerForCreationDto dto)
        {
            var data = await this.repository.SelectAllAsync();
            var item = data.FirstOrDefault(x => x.Email == dto.Email);
            if (item != null)
                throw new ChronoScholarExceptions(400, "User is already exist");
            await GenerateIdAsync();

            var seller = new Seller()
            {
                Id = _id,
                Name = dto.Name,
                Email = dto.Email,
                Pasword = dto.Pasword,
                CreatedAt = DateTime.UtcNow
            };
            var respons = await this.repository.InsertAsync(seller);

            var result = new SellerForResultDto
            {
                Id = _id,
                Name = seller.Name,

            };
            return result;

        }

        public async Task<List<SellerForResultDto>> GetAllAsync()
        {
            var data = await this.repository.SelectAllAsync();
            List<SellerForResultDto> ls = new List<SellerForResultDto>();
            foreach (var item in data)
            {
                var sellerMapping = new SellerForResultDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                ls.Add(sellerMapping);
            }
            return ls;
        }

        public async Task<SellerForResultDto> GetByIdAsync(long id)
        {
            var data = await this.repository.SelectByIdAsync(id);
            if (data == null)
                throw new ChronoScholarExceptions(404, "Seller is not found");

            var result = new SellerForResultDto()
            {
                Id = data.Id,
                Name = data.Name,
            };
            return result;

        }

        public async Task<bool> RemoveAsync(long id)
        {
            var data = await this.repository.SelectByIdAsync(id);
            if (data == null)
                throw new ChronoScholarExceptions(404, "Seller is not found");

            return await this.repository.DeleteAsync(id);

        }

        public async Task<SellerForResultDto> UpdateAsync(SellerForUpdateDto dto)
        {
            var data = await this.repository.SelectByIdAsync(dto.Id);
            if (data == null)
                throw new ChronoScholarExceptions(404, "Seller is not found");

            var updateSeller = new Seller()
            {
                Id = dto.Id,
                Name = dto.Name
            };

            await this.repository.UpdateAsync(updateSeller);

            var mappedSeller = new SellerForResultDto()
            {
                Id = updateSeller.Id,
                Name = dto.Name,
            };

            return mappedSeller;

        }


        public async Task<long> GenerateIdAsync()
        {
            var users = await this.repository.SelectAllAsync();
                var count = users.Count();
                if (count == 0)
                {
                    _id = 1;
                }
                else
                {
                    var user = users[count - 1];
                    _id = (int)(++user.Id);
                }
                return _id;
        }
        
    }
}

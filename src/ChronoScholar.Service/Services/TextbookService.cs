using ChronoScholar.Data.IRepositories;
using ChronoScholar.Data.Repositories;
using ChronoScholar.Domain.Entities;
using ChronoScholar.Service.Dto.TextbookDto;
using ChronoScholar.Service.Exceptions;
using ChronoScholar.Service.Interfaces.Textbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Services
{
    public class TextbookService:ITextbookService
    {
        private readonly IRepository<Textbook> repository = new Repository<Textbook>();
        private readonly IRepository<User> userRepository = new Repository<User>();
        private readonly IRepository<Seller> sellerRepository = new Repository<Seller>();

        private long _id;
        public async Task<TextbookForResultDto> CreateAsync(TextbookForCreationDto dto)
        {
            var data = await repository.SelectAllAsync();
            var item = data.FirstOrDefault(x => x.Email == dto.Email);
            if (item != null)
                throw new ChronoScholarExceptions(400, "textbook is already exist");

            var user = await this.userRepository.SelectByIdAsync(dto.UserId);
            if (user is null)
                throw new ChronoScholarExceptions(404, "User is not found");

            /*var seller = await this.sellerRepository.SelectByIdAsync(dto.SellerId);
            if (seller is null)
                throw new ChronoScholarExceptions(404, "Seller is not found");*/
            await GenerateIdAsync();

            var response = new Textbook()
            {
                Id=_id,
                Title = dto.Title,
                Price = dto.Price,
                Email = dto.Email,
                Author = dto.Author,
                UserId = dto.UserId,
                SellerId = dto.SellerId,
                Edition = dto.Edition,
                Condition = dto.Condition,
                CreatedAt = DateTime.UtcNow,
                Description = dto.Description,

            };
            var result = await this.repository.InsertAsync(response);

            var forResultData = new TextbookForResultDto()
            {
                Id = _id,
                Title = result.Title,
                Price = result.Price,
                UserId = result.UserId,
                SellerId = result.SellerId,
                Author = result.Author,
                Edition = result.Edition,
                Condition = result.Condition,
                Description = result.Description,
            };
            return forResultData;
        }

        public async Task<List<TextbookForResultDto>> GetAllAsync()
        {
            var data = await this.repository.SelectAllAsync();
            List<TextbookForResultDto> ls = new List<TextbookForResultDto>();
            foreach (var item in data)
            {
                var textbooxMapping = new TextbookForResultDto()
                {
                    Id = item.Id,
                    Price = item.Price,
                    Title = item.Title,
                    Author = item.Author,
                    Edition = item.Edition,
                    UserId= item.UserId,
                    SellerId = item.SellerId,
                    Condition = item.Condition,
                    Description = item.Description,


                };
                ls.Add(textbooxMapping);
            }
            return ls;

        }

        public async Task<TextbookForResultDto> GetByIdAsync(long id)
        {
            var data = await this.repository.SelectByIdAsync(id);
            if (data == null)
            {
                throw new ChronoScholarExceptions(404, "Textbook is not found");

            }


            var itemmapping = new TextbookForResultDto()
            {
                Id = data.Id,
                Title = data.Title,
                Price = data.Price,
                Author = data.Author,
                UserId = data.UserId,
                SellerId = data.SellerId,   
                Edition = data.Edition,
                Condition = data.Condition,
                Description = data.Description,


            };
            return itemmapping;

        }

        public async Task<bool> RemoveAsync(long id)
        {
            var data = await repository.SelectByIdAsync(id);
            if (data == null)
                throw new ChronoScholarExceptions(404, "Textbook is not found");

            return await this.repository.DeleteAsync(id);
        }

        public async Task<TextbookForResultDto> UpdateAsync(TextbookForUpdateDto dto)
        {
            var data = await this.repository.SelectByIdAsync(dto.Id);
            if (data == null)
                throw new ChronoScholarExceptions(404, "Texbook is not found");

            var mappedTextbook = new Textbook()
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,


            };

            await this.repository.UpdateAsync(mappedTextbook);

            return new TextbookForResultDto()
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,

            };
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

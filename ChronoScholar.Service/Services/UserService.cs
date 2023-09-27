using ChronoScholar.Data.IRepositories;
using ChronoScholar.Data.Repositories;
using ChronoScholar.Domain.Entities;
using ChronoScholar.Service.Dto.UserDto;
using ChronoScholar.Service.Exceptions;
using ChronoScholar.Service.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> userRepository = new Repository<User>();
        private int _id;

        public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
        {

            var user = (await this.userRepository.SelectAllAsync())
                .FirstOrDefault(x => x.Email.ToLower() == dto.Email.ToLower());
            if (user is not null)
                throw new ChronoScholarExceptions(400, "User is already exist");

            await GenerateIdAsync();
            var person = new User()
            {
                Id = _id,

                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.UtcNow,
                PhoneNumber = dto.PhoneNumber,

            };

            var response = await this.userRepository.InsertAsync(person);

            var result = new UserForResultDto()
            {
                Id = _id,
                Name = dto.Name,
                Lacation = dto.Lacation,
                PhoneNumber = dto.PhoneNumber,

            };

            return result;


        }

        public async Task<List<UserForResultDto>> GetAllAsync()
        {
            var data = await this.userRepository.SelectAllAsync();
            var result = new List<UserForResultDto>();
            foreach (var item in data)
            {
                var person = new UserForResultDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Lacation = item.Lacation,
                    PhoneNumber = item.PhoneNumber,

                };
                result.Add(person);
            }

            return result;
        }

        public async Task<UserForResultDto> GetByIdAsync(long id)
        {
            var data = await this.userRepository.SelectByIdAsync(id);
            if (data == null)
            {
                throw new ChronoScholarExceptions(404, "User is not found");
            }

            var person = new UserForResultDto()
            {
                Id = data.Id,
                Name = data.Name,
                Lacation = data.Lacation,
                PhoneNumber = data.PhoneNumber,

            };
            return person;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var datas = await this.userRepository.SelectByIdAsync(id);
            if (datas is null)
                throw new ChronoScholarExceptions(404, "User is not found");

            return await this.userRepository.DeleteAsync(datas.Id);
        }

        public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
        {
            var user = await this.userRepository.SelectByIdAsync(dto.Id);
            if (user is null)
                throw new ChronoScholarExceptions(404, "User is not found");

            var person = new User()
            {
                Id = dto.Id,
                Name = dto.Name,
                Lacation = dto.Lacation,
                UpdatedAt = DateTime.UtcNow,
                PhoneNumber = dto.PhoneNumber,

            };

            await this.userRepository.UpdateAsync(person);

            var result = new UserForResultDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Lacation = dto.Lacation,
                PhoneNumber = dto.PhoneNumber,

            };

            return result;
        }

        // Generation Id
        public async Task<long> GenerateIdAsync()
        {
            var users = await userRepository.SelectAllAsync();
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

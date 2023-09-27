using ChronoScholar.Service.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Interfaces.User
{
    public interface IUserService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<UserForResultDto>> GetAllAsync();
        public Task<UserForResultDto> GetByIdAsync(long id);
        public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
        public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    }
}

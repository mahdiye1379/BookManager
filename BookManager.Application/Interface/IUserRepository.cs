using BookManager.Domain.DTO;

namespace BookManager.Application.Interface
{
    public interface IUserRepository
    {
        public  Task<(bool, string)> Login(LoginDto loginDto);
        public Task<(string, bool)> Register(RegisterDTO registerDTO);

    }
}

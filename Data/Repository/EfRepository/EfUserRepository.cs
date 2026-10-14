using BookManager.Domain.DTO;
using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Repository.EfRepository
{
    public class EfUserRepository : IUserRepository
    {
        BookManager_DbContext _dbContext;
        public EfUserRepository(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool, string)> Login(LoginDto loginDto)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);
            if (user is null)
            {
                return (false, "اطلاعات ورود درست نیست");
            }
            return (true, ",وارد شدید");
        }

        public async Task<(string,bool)> Register(RegisterDTO registerDTO)
        {
            string RegisterMsg = "";
            bool IsFresh = false;

            User? UserDb_Email = _dbContext.Users.FirstOrDefault(x => x.Email == registerDTO.Email);
            if (UserDb_Email is not null)
            {
                RegisterMsg += " ,ایمیل";
                IsFresh = true;
            }

            User? UserDb_UserName = _dbContext.Users.FirstOrDefault(x => x.UserName == registerDTO.UserName);
            if (UserDb_Email is not null)
            {
                RegisterMsg += " ,نام کاربری";
                IsFresh = true;
            }

            User? UserDb_Phone = _dbContext.Users.FirstOrDefault(x => x.PhoneNumber == registerDTO.PhoneNumber);
            if (UserDb_Email is not null)
            {
                RegisterMsg += " ,شماره موبایل";
                IsFresh = true;
            }

            if (IsFresh is true)
            {
                return ($"{RegisterMsg} , از قبل وجود دارد",true);
            }

            User user = new()
            {
                Email = registerDTO.Email,
                Password = registerDTO.Password,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.UserName,
                IsActive = false,
                CreatedAtUtc = DateTime.UtcNow,
            };

            try
            {

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return ("کاربر با موفقیت اضافه شد",true);

            }
            catch (Exception ex) 
            {

#if DEBUG
                Exception exi = ex.InnerException;
                return (exi is not null ? exi.Message : ex.Message, false);
#else
                    return ("خطایی در اضافه کردن کاربر بوجود امده است",false);
#endif
            }

        }
    }
}

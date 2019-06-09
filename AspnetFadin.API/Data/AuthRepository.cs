using System;
using System.Security.Criptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using AspnetFadin.API.Models;

namespace AspnetFadin.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
            
        }

        public async Task<User> Register(User user, string password) 
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(password, out passwordHash, out passwordSalt)
        {
            using (var hmac = new System.Security.Criptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputerHash(System.text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
               return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)){
                return null;
            } 

            return user;        

        }

        private bool VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)
        {
            using( var hmac = new System.Security.Criptography.HMACSHA512(passwordSalt)) 
            {
                  var computedHash = hmac.ComputerHash(System.text.Encoding.UTF8.GetBytes(password));
                  for (int i = 0; i < computedHash.Length; i++)
                  {
                      if (computedHash[i] != passwordHash[i])
                      {
                          return false;
                      }
                  }                  
            }
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
           if (await _context.Users.AnyAsync(x => x.Username == username))
           {
              return true;
           }
           return false;
        }
        
    }
}
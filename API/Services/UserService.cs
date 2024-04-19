using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Context;

namespace API.Services
{
    public class UserService
    {
        private readonly DbSet<User> _dbSet;
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task SignUp(User user)
        {
            var data = new User 
            { 
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            _dbSet.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SignIn(string username, string password)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);

            return user != null;
        }
    }
}

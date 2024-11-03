using ProjectManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUsername(string username);
        Task<IEnumerable<User?>> GetEmployees();
    }
}

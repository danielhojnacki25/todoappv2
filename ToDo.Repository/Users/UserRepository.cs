using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Repository.Users;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
}
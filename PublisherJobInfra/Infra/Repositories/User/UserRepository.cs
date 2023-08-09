using Microsoft.EntityFrameworkCore;
using PublisherJobInfra.Infra.Data;
using PublisherJobInfra.Infra.Entities;
using PublisherJobInfra.Infra.Interfaces.User;

namespace PublisherJobInfra.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var user = context.User.AsNoTracking();
                return user.ToList();
            }
        }
    }
}

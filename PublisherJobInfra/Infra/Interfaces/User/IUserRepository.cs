using PublisherJobInfra.Infra.Entities;

namespace PublisherJobInfra.Infra.Interfaces.User
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> Get();
    }
}

using PublisherJobInfra.Infra.Entities;

namespace PublisherJob.Service.User
{
    public interface IUserService
    {
        IEnumerable<UserEntity> Get();
    }
}

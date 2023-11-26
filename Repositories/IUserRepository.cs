using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Repositories
{
    public interface IUserRepository
    {
        void Add(UserDTO user);
        void Delete(UserDTO user);
        UserDTO Get(Guid userId);
        IEnumerable<UserDTO> GetAll();
        void Update(UserDTO updatedUser);
    }
}
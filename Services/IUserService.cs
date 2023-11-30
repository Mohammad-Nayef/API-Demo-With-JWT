using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Services
{
    public interface IUserService
    {
        void Add(UserDTO user);
        bool Delete(UserDTO user);
        UserDTO Get(Guid userId);
        IEnumerable<UserDTO> GetAll();
        void Update(UserDTO updatedUser);
    }
}
using MinimalApiWithJwt.Models;
using MinimalApiWithJwt.Repositories;

namespace MinimalApiWithJwt.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(UserDTO user) => _repository.Add(user);

        public UserDTO Get(Guid userId) => _repository.Get(userId);

        public IEnumerable<UserDTO> GetAll() => _repository.GetAll();

        public void Update(UserDTO updatedUser) => _repository.Update(updatedUser);

        public bool Delete(UserDTO user) => _repository.Delete(user);
    }
}

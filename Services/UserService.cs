using MinimalApiWithJwt.Models;
using MinimalApiWithJwt.Repositories;

namespace MinimalApiWithJwt.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDTO user) => _userRepository.Add(user);

        public UserDTO Get(Guid userId) => _userRepository.Get(userId);

        public IEnumerable<UserDTO> GetAll() => _userRepository.GetAll();

        public void Update(UserDTO updatedUser) => _userRepository.Update(updatedUser);

        public bool Delete(UserDTO user) => _userRepository.Delete(user);
    }
}

using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<UserDTO> _users = new List<UserDTO>();

        public void Add(UserDTO user) => _users.Add(user);

        public UserDTO Get(Guid userId) => _users.Find(user => user.Id == userId);

        public List<UserDTO> GetAll() => new List<UserDTO>(_users);

        public void Update(UserDTO updatedUser)
        {
            var user = Get(updatedUser.Id);
            user = updatedUser;
        }

        public bool Delete(UserDTO user) => _users.Remove(user);
    }
}

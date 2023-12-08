using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Repositories
{
    /// <summary>
    /// Responsible for managing user data and do CRUD operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        void Add(UserDTO user);

        /// <summary>
        /// Deletes a user from the repository.
        /// </summary>
        /// <returns>true if the user is successfully deleted; otherwise, false</returns>
        bool Delete(UserDTO user);

        /// <summary>
        /// Gets a user by his Id value.
        /// </summary>
        /// <returns>UserDTO containing the needed user.</returns>
        UserDTO Get(Guid userId);

        /// <summary>
        /// Gets all of the users stored in the repository.
        /// </summary>
        /// <returns>Collection of UserDTO.</returns>
        List<UserDTO> GetAll();

        /// <summary>
        /// Finds and update a user.
        /// </summary>
        void Update(UserDTO updatedUser);
    }
}
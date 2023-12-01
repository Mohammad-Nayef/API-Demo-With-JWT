using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Services
{
    /// <summary>
    /// Responsible for provide client code to deal with the users repository.
    /// </summary>
    public interface IUserService
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
        IEnumerable<UserDTO> GetAll();

        /// <summary>
        /// Finds and update a user.
        /// </summary>
        void Update(UserDTO updatedUser);
    }
}
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    /* A method that returns a list of users. */
    IList<User> Get();
    /// <summary>
    /// GetById returns a User object with the given id.
    /// </summary>
    /// <param name="id">The id of the user you want to get.</param>
    User GetById(int id);
    /// <summary>
    /// This function posts a user to the database
    /// </summary>
    /// <param name="User">The user object that you want to post.</param>
    void Post(User user);
    /// <summary>
    /// This function takes a user object and puts it into the database.
    /// </summary>
    /// <param name="User">The user object to be saved.</param>
    void Put(User user);
    /// <summary>
    /// Delete the user from the database.
    /// </summary>
    /// <param name="User">The user to delete.</param>
    void Delete(User user);
}

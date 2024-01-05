using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repositories;
using TestCasePHEV2.Repository;
using TestCasePHEV2.Utilities.Handler;

public class UserServices
{
    private readonly UserRepository _userRepository;
    private readonly TestCasePHEV2DbContext context;
    private readonly RoleRepository _roleRepository;

    public UserServices(TestCasePHEV2DbContext context)
    {
        _roleRepository = new RoleRepository(context);
        _userRepository = new UserRepository(context);
    }

    public RegistrationResult RegisterAccount(User registerDto)
    {
        try
        {
            var userRoleGuid = "968af342-eb27-4476-9a60-1e1b070739b8";

            // Create a new GUID for the employee
            var userGuid = Guid.NewGuid().ToString();

            // Create an Employee entity
            var User = new User
            {
                Guid = userGuid,
                Username = registerDto.Username,
                Password = Hashing.HashPassword(registerDto.Password),
                CompanyGuid = registerDto.CompanyGuid,
                RoleGuid = userRoleGuid, // Use the GUID of the default role
            };

            // Save the employee to the database
            _userRepository.Add(User);

            return RegistrationResult.Success;
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            Console.WriteLine(ex.ToString());
            return RegistrationResult.UnknownError;
        }
    }

    public enum RegistrationResult
    {
        Success = 1,
        EmailAlreadyExists = 2,
        UnknownError = 0
    }

    public IEnumerable<User> GetAllUser()
    {
        return _userRepository.GetAll();
    }
    public User GetUserByGuid(string guid)
    {
        var user = _userRepository.GetByGuid(guid);

        return user;
    }

    // Update
    public void UpdateUser(User updatedUser)
    {
        _userRepository.Update(updatedUser);
    }

    // Delete
    public void DeleteUser(string guid)
    {
        try
        {
            var user = _userRepository.GetByGuid(guid);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            Console.WriteLine(ex.ToString());
            // You may want to throw an exception or return a specific result here
        }
    }

    public User GetUserByUsername(string username)
    {
        return _userRepository.GetByUsername(username);
    }

    public Role GetRoleNameByGuid(string roleGuid)
    {
        return _userRepository.GetRoleByGuid(roleGuid);
    }

    public bool ValidatePassword(string username, string password)
    {
        var user = _userRepository.GetByUsername(username);

        if (user != null)
        {
            return Hashing.ValidatePassword(password, user.Password);
        }

        return false;
    }

    public IEnumerable<string> GetRoles(string guid)
    {
        var roles = _userRepository.GetRolesByUserGuid(guid);

        if (roles.Any())
        {
            return roles.Select(role => role.Name);
        }

        return Enumerable.Empty<string>();
    }

}

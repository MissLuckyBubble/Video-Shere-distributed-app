using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Authentication
{
    public class ValidateRepo : IDisposable
    {
        UserManagmentService userManagment = new UserManagmentService();

        public void Dispose()
        {
            
        }

        public UserDTO ValidateUser(string username, string password)
        {
            List<UserDTO> users = new List<UserDTO>();
            users = userManagment.Get();
            return users.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}
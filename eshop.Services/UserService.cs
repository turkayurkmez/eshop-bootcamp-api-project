using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services
{
   public class UserService
    {
        private List<User> users = new List<User>
        {
             new User { Id=1, Name="admin", UserName="system", Password="123", Role="Admin"},
             new User { Id=2, Name="user", UserName="ali", Password="1234", Role="User"},
             new User { Id=3, Name="editor", UserName="turkay", Password="123", Role="Editor"},

        };
        public User IsValid(string username, string password)
        {
            return users.FirstOrDefault(x => x.UserName == username && x.Password == password);

        }
    }
}

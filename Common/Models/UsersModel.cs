using System;
using System.Collections.Generic;

namespace PrintManagement.Common.Models
{
   public class UsersModel
    {

        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SecurityQuestionId { get; set; }
        public string SecurityAnswer { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        

    }
}

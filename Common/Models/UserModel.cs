namespace PrintManagement.Common.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SecurityQuestionId { get; set; }
        public string SecurityAnswer { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

    }
}

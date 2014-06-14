using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BE
{
    public class UsersBE
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public UsersBE(){}

        public UsersBE(Guid userId)
        {
            this.UserId = userId;
        }

        public UsersBE(string userName, string email, DateTime createDate, DateTime lastLoginDate)
        {
            this.UserName = userName;
            this.Email = email;
            this.CreateDate = createDate;
            this.LastLoginDate = lastLoginDate;
        }

        public UsersBE(Guid id, string userName, string email, DateTime createDate, DateTime lastLoginDate)
        {
            this.UserId = id;
            this.UserName = userName;
            this.Email = email;
            this.CreateDate = createDate;
            this.LastLoginDate = lastLoginDate;
        }

        public UsersBE(Guid id, string userName, string email)
        {
            this.UserId = id;
            this.UserName = userName;
            this.Email = email;
        }
    }
}

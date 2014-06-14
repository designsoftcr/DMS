using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BE
{
    public class WorkGroupsBE
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId  { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int TotalUsers { get; set; }
        public List<UsersBE> Users { get; set; }

        public WorkGroupsBE(){}

        public WorkGroupsBE(Guid roleId)
        {
            this.RoleId = roleId;
        }

        public WorkGroupsBE(Guid roleId, string roleName)
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
        }

        public WorkGroupsBE( Guid roleId, string roleName, int totalUsers )
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.TotalUsers = totalUsers;
        }

        public WorkGroupsBE( Guid applicationId, Guid roleId, string roleName, string description )
        {
            this.ApplicationId = applicationId;
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.Description = description;
        }

        public WorkGroupsBE(Guid roleId, string roleName, List<UsersBE> users)
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.Users = users;
        }

    }
}

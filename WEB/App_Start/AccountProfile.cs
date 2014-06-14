using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace WEB
{
    public class AccountProfile : ProfileBase
    {

        static public AccountProfile CurrentUser
        {
            get
            {
                if (Membership.GetUser() != null)
                    return ProfileBase.Create(Membership.GetUser().UserName) as AccountProfile;
                else
                    return null;
            }
        }

        public string UserId
        {
            get { return ((string)(base["UserId"])); }
            set { base["UserId"] = value; Save(); }
        }

        public string Culture
        {
            get { return ((string)(base["Culture"])); }
            set { base["Culture"] = value; Save(); }
        }

        public string CurrentCompanyName
        {
            get { return ((string)(base["CurrentCompanyName"])); }
            set { base["CurrentCompanyName"] = value; Save(); }
        }

        public string CurrentCompanyId
        {
            get { return ((string)(base["CurrentCompanyId"])); }
            set { base["CurrentCompanyId"] = value; Save(); }
        }

        public string ExternalId
        {
            get { return ((string)(base["ExternalId"])); }
            set { base["ExternalId"] = value; Save(); }
        }

        public string Name
        {
            get { return ((string)(base["Name"])); }
            set { base["Name"] = value; Save(); }
        }

    }
}
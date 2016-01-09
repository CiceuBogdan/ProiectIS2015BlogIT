using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogIT.BusinessLogic.Interfaces;

namespace BlogIT.BusinessLogic
{
    public class UserBL: IUserBL
    {
        

        public bool Login(string password)
        {
            if (password.Equals("1234!a"))
                return true;
            else
                return false;
        }
    }
}
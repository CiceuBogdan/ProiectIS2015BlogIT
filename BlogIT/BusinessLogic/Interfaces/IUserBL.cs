using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogIT.BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        bool Login(string password);
    }
}

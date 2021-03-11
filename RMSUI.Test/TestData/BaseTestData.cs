using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.UI.Test.TestData
{
    public class BaseTestData
    {
        public class Admin
        {
            public const string LOGIN_NAME = "alice";
            public const string LOGIN_PASSWORD = "Abc123$";
        }

        public const string CARD_LOGIN = "cardLogin";
        public const string USERNAME_PASSWORD_LOGIN = "userNamePasswordLogin";

        public class RMSMenuConstants
        {
            public const string DASHBOARD = "Dashboard";

            public const string BOXOFFICE = "BOXOFFICE";
            public const string BOXOFFICE_POS = "BoxOfficePos";
            public const string BOXOFFICE_POS_TICKETSALES = "TicketSales";
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using agkik.businesslogic.models;
using System.Data;
using log4net;
using System.Reflection;

namespace agkik.businesslogic.businessapi
{
    public class UserManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static User getUserByUserName(string username)
        {
            AgkikdbEntities entity = new AgkikdbEntities();

            IQueryable<user> query = from it in entity.users
                                     where it.UserName == username
                                     select it;

            try
            {

                if (query.Count<user>() == 1)
                {
                    user userTbl = query.First<user>();
                    if (userTbl != null)
                    {
                        Role usrRole;
                        switch (userTbl.role.Description.ToUpperInvariant())
                        {
                            case "ADMIN": usrRole = Role.Admin; break;
                            case "MANAGER": usrRole = Role.Manager; break;
                            case "SALESMAN": usrRole = Role.SalesMan; break;
                            default: usrRole = Role.Other; break;
                        }
                        
                        return new User()
                        {
                            FirstName = userTbl.FirstName,
                            LastName = userTbl.LastName,
                            UserName = userTbl.UserName,
                            Password = userTbl.Password,
                            UserRole = usrRole
                        };
                    }
                }
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return new User()
                {
                    HasError = true,
                    ErrorMessage = "Database connection error!"
                };
            }
            return null;
        }
    }
}

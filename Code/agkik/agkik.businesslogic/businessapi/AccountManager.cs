using log4net;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace agkik.businesslogic.businessapi
{
    public class AccountManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static List<account> getAccounts()
        {
            AgkikdbEntities entity = new AgkikdbEntities();
            IQueryable<account> vendors = (from acc in entity.accounts
                                          select acc).OrderBy(x => x.AccountBalance) ;

            return vendors.ToList<account>();
        }
    }
}

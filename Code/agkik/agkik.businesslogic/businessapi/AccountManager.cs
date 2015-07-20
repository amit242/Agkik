using log4net;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using agkik.businesslogic.models;
using System.Data;

namespace agkik.businesslogic.businessapi
{
    public class AccountManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static List<account> GetAccounts()
        {
            AgkikdbEntities entity = new AgkikdbEntities();
            IQueryable<account> accounts = (from acc in entity.accounts
                                          select acc).OrderBy(x => x.AccountBalance) ;

            return accounts.ToList<account>();
        }

        public static ResponseWrapper AddUpdateAccount(account accountTobeAddedOrUpdated)
        {
            
            AgkikdbEntities entity = new AgkikdbEntities();
            if (accountTobeAddedOrUpdated.idBankAccounts == 0)
            {
                entity.AddToaccounts(accountTobeAddedOrUpdated);
            }
            else
            {
                IQueryable<account> accountsTobeUpdated = from acc in entity.accounts
                                                          where acc.idBankAccounts == accountTobeAddedOrUpdated.idBankAccounts
                                                          select acc;
                if (accountsTobeUpdated.Count<account>() != 1)
                {
                    return new ResponseWrapper()
                                {
                                    HasError = true,
                                    ErrorMessage = "Could not find the account"
                                };
                }
                //account accTobeUpdated = entity.accounts.First<account>(i => i.idBankAccounts == accountTobeAddedOrUpdated.idBankAccounts);
                account accTobeUpdated = accountsTobeUpdated.First<account>();
                accTobeUpdated = accountTobeAddedOrUpdated;
            }
            try
            {
                int effectedRows = entity.SaveChanges();
                log.Debug(string.Format("effeced rows[{0}]", effectedRows));
                return new ResponseWrapper()
                            {
                                HasError = effectedRows > 0
                            };
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return new ResponseWrapper()
                            {
                                HasError = true,
                                ErrorMessage = ex.Message
                            };
            }

            
            //entity.vendors.First<account>(i => i.idVendors == account);
        }
    }
}

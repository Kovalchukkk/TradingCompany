using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IAccountDal
    {
        List<AccountDTO> GetAllAccounts();
        AccountDTO CreateAccount(AccountDTO account);
    }
}

using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class AccountDal : IAccountDal
    {
        private readonly IMapper mapper;
        public AccountDal(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public AccountDTO CreateAccount(AccountDTO account)
        {
            using (var entities = new TradingCompany2022TESTEntities())
            {
                var accountDB = mapper.Map<Account>(account);
                accountDB.CreatedAt = DateTime.UtcNow;
                entities.Accounts.Add(accountDB);
                entities.SaveChanges();
                return mapper.Map<AccountDTO>(accountDB);
            }
        }

        public List<AccountDTO> GetAllAccounts()
        {
            using (var entities = new TradingCompany2022TESTEntities())
            {
                var accounts = entities.Accounts.ToList();
                return mapper.Map<List<AccountDTO>>(accounts);
            }
        }
    }
}

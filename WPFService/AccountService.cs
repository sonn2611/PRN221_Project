using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFRepo;

namespace WPFService
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository = null;
        public AccountService()
        {
            accountRepository = new AccountRepository();
        }
        public Account GetAccountByEmail(string email) => accountRepository.GetAccountByEmail(email);
        public void RegisterAccount(string email, string password, string gender, string role, string masv) => accountRepository.RegisterAccount(email, password, gender, "Student", masv);
        public bool AddAccount(Account account) => accountRepository.AddAccount(account);

        public Account GetAccountByRole(string role) => accountRepository.GetAccountByRole(role);
    }
}

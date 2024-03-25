using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFDAO;

namespace WPFRepo
{
    public class AccountRepository : IAccountRepository
    {
        public void RegisterAccount(string email, string password, string gender, string role, string masv) => AccountDAO.Instance.RegisterAccount(email, password, gender, "Student", masv);

        public Account GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);

        public bool AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public Account GetAccountByRole(string role) => AccountDAO.Instance.GetAccountByRole(role);
    }
}

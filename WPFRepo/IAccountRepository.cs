using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFRepo
{
    public interface IAccountRepository
    {
        Account GetAccountByEmail(string email);
        void RegisterAccount(string email, string password, string gender, string role, string masv);
        bool AddAccount(Account account);
        Account GetAccountByRole(string role);
    }
}

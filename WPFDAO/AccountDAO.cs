using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFDAO
{
    public class AccountDAO
    {
        private readonly QLSVContext _db = null;
        private static AccountDAO instante = null;

        public static AccountDAO Instance
        {
            get
            {
                if (instante == null)
                {
                    return new AccountDAO();
                }
                return instante;
            }
        }
        public AccountDAO()
        {
            _db = new QLSVContext();
        }

        public Account GetAccountById(string id)
        {
            return _db.Accounts.SingleOrDefault(x => x.Id.Equals(id));
        }
        public Account GetAccountByRole(string role)
        {
            return _db.Accounts.SingleOrDefault(x => x.Role == role);
        }
        public List<Account> GetAccountByMasv(string masv)
        {
            return _db.Accounts.Where(x => x.Masv == masv).ToList();
        }
        public Account GetAccountByEmail(string email)
        {
            return _db.Accounts.SingleOrDefault(x => x.Email == email);
        }
        public bool AddAccount(Account account)
        {
            bool result = false;
            try
            {
                _db.Add(account);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public void RegisterAccount(string email, string password, string gender, string role, string masv)
        {
            Account account = new Account()
            {
                Email = email,
                Password = password,
                Gender = gender,
                Role = "Student",
                Masv = masv
            };
        }
    }
}

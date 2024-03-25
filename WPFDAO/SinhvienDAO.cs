using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFDAO
{
    public class SinhvienDAO
    {
        private readonly QLSVContext _db = null;
        private static SinhvienDAO instante = null;

        public static SinhvienDAO Instance
        {
            get
            {
                if (instante == null)
                {
                    return new SinhvienDAO();
                }
                return instante;
            }
        }
        public SinhvienDAO()
        {
            _db = new QLSVContext();
        }
        public IEnumerable<TopSinhVien> GetStudentsWithAveragePoints(IEnumerable<Sinhvien> students, IEnumerable<Diemsv> subjects, string classIdToCheck)
        {
            var query = from s in students
                        join sub in subjects on s.Masv equals sub.Masv
                        where s.Malp == classIdToCheck
                        group sub by new { s.Masv, s.Tensv } into g
                        select new TopSinhVien
                        {
                            Id = g.Key.Masv,
                            Tenhocsinh = g.Key.Tensv,
                            Diemtb = g.Average(sub => sub.Diem)
                        };
            return query.ToList();
        }
        public Sinhvien GetSinhvienById(string id)
        {
            return _db.Sinhviens.SingleOrDefault(x => x.Masv == id);
        }
        public List<Sinhvien> GetAllSinhVien()
        {
            return _db.Sinhviens.ToList();
        }
        public bool AddSinhvien(Sinhvien sv)
        {
            bool result = false;
            try
            {
                _db.Add(sv);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool UpdateSinhvien(Sinhvien sv)
        {
            bool result = false;
            try
            {
                _db.Update(sv);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool DeleteSinhvien(string id)
        {
            bool result = false;
            Sinhvien studentToDelete = GetSinhvienById(id);
            try
            {
                List<Diemsv> diemList = DiemsvDAO.Instance.GetDiemsvByMasv(id);
                foreach (var diem in diemList)
                {
                    _db.Diemsvs.Remove(diem);
                }
                List<Account> accounts = AccountDAO.Instance.GetAccountByMasv(id);
                foreach (var account in accounts)
                {
                    _db.Accounts.Remove(account);
                }
                _db.Sinhviens.Remove(studentToDelete);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }

        public List<Sinhvien> GetSinhvienByLop(string malop)
        {
            return _db.Sinhviens.Where(x => x.Malp == malop).ToList();
        }
        public List<Sinhvien> GetSinhvienByName(string name)
        {
            return _db.Sinhviens.Where(x => x.Tensv.Contains(name)).ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFDAO
{
    public class MonhocDAO
    {
        private readonly QLSVContext _db = null;
        private static MonhocDAO instance = null;
        public static MonhocDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new MonhocDAO();
                }
                return instance;
            }
        }
        public MonhocDAO()
        {
            _db = new QLSVContext();
        }
        public List<Monhoc> GetAllMonhoc()
        {
            try
            {
                return _db.Monhocs.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Sinhvien> GetStudentsInMonHoc(string monHocId)
        {

            var studentsInMonHoc = from monHoc in _db.Monhocs
                                   join diemSv in _db.Diemsvs on monHoc.Mamh equals diemSv.Mamh
                                   join student in _db.Sinhviens on diemSv.Masv equals student.Masv
                                   where monHoc.Mamh == monHocId
                                   select student;

            return studentsInMonHoc.ToList();
        }

        public Monhoc GetMonhocById(string id)
        {
            return _db.Monhocs.SingleOrDefault(c => c.Mamh.Equals(id));
        }
        public Monhoc GetMonhocByName(string name)
        {
            return _db.Monhocs.SingleOrDefault(c => c.Tenmh.Equals(name));
        }
        public bool AddMonhoc(Monhoc monhoc)
        {
            bool result = false;
            try
            {
                _db.Add(monhoc);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool UpdateMonhoc(Monhoc monhoc)
        {
            bool result = false;
            try
            {
                _db.Update(monhoc);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool DeleteMonhoc(string id)
        {
            bool result = false;
            try
            {
                var monhoc = _db.Monhocs.SingleOrDefault(c => c.Mamh.Equals(id));
                if (monhoc != null)
                {
                    _db.Remove(monhoc);
                    _db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFDAO
{
    public class DiemsvDAO
    {
        private readonly QLSVContext _db = null;
        private static DiemsvDAO instance = null;

        public static DiemsvDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new DiemsvDAO();
                }
                return instance;
            }
        }
        public DiemsvDAO()
        {
            _db = new QLSVContext();
        }
        public List<Diemsv> GetAllDiemsv()
        {
            return _db.Diemsvs.ToList();
        }
        public List<Diemsv> GetTopDiemsv()
        {
            try
            {
                return _db.Diemsvs.OrderByDescending(x => x.Diem)
                    .Include(x => x.MasvNavigation)
                    .Include(x => x.MamhNavigation)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Diemsv GetDiemsvById(string masv)
        {
            return _db.Diemsvs.SingleOrDefault(x => x.Masv == masv);
        }
        public List<Diemsv> GetDiemsvByMasv(string masv)
        {
            return _db.Diemsvs.Include(x => x.MasvNavigation).Include(x => x.MamhNavigation).Where(x => x.Masv == masv).ToList();
        }
        public Diemsv GetDiemsvByMonhoc(string name)
        {
            return _db.Diemsvs.FirstOrDefault(x => x.MamhNavigation.Tenmh == name);
        }
        public bool AddDiemsv(Diemsv diemsv)
        {
            bool result = false;
            try
            {
                _db.Add(diemsv);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool UpdateDiemsv(Diemsv diemsv)
        {
            bool result = false;
            try
            {
                //var currentDiemsv = _db.Diemsvs.SingleOrDefault(x => x.Masv == diemsv.Masv && x.Mamh == diemsv.Mamh);
                //if (currentDiemsv != null)
                //{
                //    currentDiemsv.Diem = diemsv.Diem;
                //    _db.SaveChanges();
                //    result = true;
                //}
                _db.Update(diemsv);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
        public bool DeleteDiemsv(string masv, string mamh)
        {
            bool result = false;
            try
            {
                var currentDiemsv = _db.Diemsvs.SingleOrDefault(x => x.Masv == masv && x.Mamh == mamh);
                if (currentDiemsv != null)
                {
                    _db.Remove(currentDiemsv);
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

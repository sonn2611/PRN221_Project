using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFDAO;

namespace WPFRepo
{
    public class SinhvienRepository : ISinhvienRepository
    {
        public bool AddSinhvien(Sinhvien sv) => SinhvienDAO.Instance.AddSinhvien(sv);

        public bool DeleteSinhvien(string id) => SinhvienDAO.Instance.DeleteSinhvien(id);

        public IEnumerable<TopSinhVien> GetStudentsWithAveragePoints(IEnumerable<Sinhvien> students, IEnumerable<Diemsv> subjects, string classIdToCheck) => SinhvienDAO.Instance.GetStudentsWithAveragePoints(students, subjects, classIdToCheck);

        public List<Sinhvien> GetAllSinhVien() => SinhvienDAO.Instance.GetAllSinhVien();

        public Sinhvien GetSinhvienById(string id) => SinhvienDAO.Instance.GetSinhvienById(id);
        public List<Sinhvien> GetSinhvienByLop(string malop) => SinhvienDAO.Instance.GetSinhvienByLop(malop);

        public List<Sinhvien> GetSinhvienByName(string name) => SinhvienDAO.Instance.GetSinhvienByName(name);

        public bool UpdateSinhvien(Sinhvien sv) => SinhvienDAO.Instance.UpdateSinhvien(sv);
    }
}

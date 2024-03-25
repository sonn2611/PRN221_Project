using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFRepo
{
    public interface ISinhvienRepository
    {
        Sinhvien GetSinhvienById(string id);
        List<Sinhvien> GetAllSinhVien();
        bool AddSinhvien(Sinhvien sv);
        bool UpdateSinhvien(Sinhvien sv);
        bool DeleteSinhvien(string id);
        List<Sinhvien> GetSinhvienByLop(string malop);
        List<Sinhvien> GetSinhvienByName(string name);
        IEnumerable<TopSinhVien> GetStudentsWithAveragePoints(IEnumerable<Sinhvien> students, IEnumerable<Diemsv> subjects, string classIdToCheck);
    }
}

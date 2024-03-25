using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFRepo;

namespace WPFService
{
    public class SinhvienService : ISinhvienService
    {
        private SinhvienRepository sinhvienRepository = null;
        public SinhvienService()
        {
            sinhvienRepository = new SinhvienRepository();
        }

        public bool AddSinhvien(Sinhvien sv) => sinhvienRepository.AddSinhvien(sv);

        public bool DeleteSinhvien(string id) => sinhvienRepository.DeleteSinhvien(id);

        public IEnumerable<TopSinhVien> GetStudentsWithAveragePoints(IEnumerable<Sinhvien> students, IEnumerable<Diemsv> subjects, string classIdToCheck) => sinhvienRepository.GetStudentsWithAveragePoints(students, subjects, classIdToCheck);

        public List<Sinhvien> GetAllSinhVien() => sinhvienRepository.GetAllSinhVien();

        public Sinhvien GetSinhvienById(string id) => sinhvienRepository.GetSinhvienById(id);

        public List<Sinhvien> GetSinhvienByLop(string malop) => sinhvienRepository.GetSinhvienByLop(malop);

        public List<Sinhvien> GetSinhvienByName(string name) => sinhvienRepository.GetSinhvienByName(name);

        public bool UpdateSinhvien(Sinhvien sv) => sinhvienRepository.UpdateSinhvien(sv);

    }
}

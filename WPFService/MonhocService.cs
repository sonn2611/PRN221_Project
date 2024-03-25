using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFRepo;

namespace WPFService
{
    public class MonhocService : IMonhocService
    {
        private MonhocRepository monhocRepository = null;
        public MonhocService()
        {
            monhocRepository = new MonhocRepository();
        }
        public bool AddMonhoc(Monhoc monhoc) => monhocRepository.AddMonhoc(monhoc);

        public bool DeleteMonhoc(string mamh) => monhocRepository.DeleteMonhoc(mamh);

        public List<Monhoc> GetAllMonhoc() => monhocRepository.GetAllMonhoc();
        public Monhoc GetMonhocById(string mamh) => monhocRepository.GetMonhocById(mamh);

        public Monhoc GetMonhocByName(string tenmh) => monhocRepository.GetMonhocByName(tenmh);

        public bool UpdateMonhoc(Monhoc monhoc) => monhocRepository.UpdateMonhoc(monhoc);
        public List<Sinhvien> GetStudentsInMonHoc(string monHocId) => monhocRepository.GetStudentsInMonHoc(monHocId);

    }
}

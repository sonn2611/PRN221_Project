using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFDAO;

namespace WPFRepo
{
    public class MonhocRepository : IMonhocRepository
    {
        public bool AddMonhoc(Monhoc monhoc) => MonhocDAO.Instance.AddMonhoc(monhoc);

        public bool DeleteMonhoc(string mamh) => MonhocDAO.Instance.DeleteMonhoc(mamh);

        public List<Monhoc> GetAllMonhoc() => MonhocDAO.Instance.GetAllMonhoc();

        public Monhoc GetMonhocById(string mamh) => MonhocDAO.Instance.GetMonhocById(mamh);

        public Monhoc GetMonhocByName(string name) => MonhocDAO.Instance.GetMonhocByName(name);

        public bool UpdateMonhoc(Monhoc monhoc) => MonhocDAO.Instance.UpdateMonhoc(monhoc);
        public List<Sinhvien> GetStudentsInMonHoc(string monHocId) => MonhocDAO.Instance.GetStudentsInMonHoc(monHocId);

    }
}

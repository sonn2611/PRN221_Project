using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFDAO;

namespace WPFRepo
{
    public class LopRepository : ILopRepository
    {
        public bool AddLop(Lop lop) => LopDAO.Instance.AddLop(lop);

        public bool DeleteLop(string malop) => LopDAO.Instance.DeleteLop(malop);

        public List<Lop> GetAllLop() => LopDAO.Instance.GetAllLop();

        public Lop GetLopById(string malop) => LopDAO.Instance.GetLopById(malop);

        public List<Lop> SearchLopById(string id) => LopDAO.Instance.SearchLopById(id);

        public List<Lop> SearchLopByName(string name) => LopDAO.Instance.SearchLopByName(name);

        public bool UpdateLop(Lop lop) => LopDAO.Instance.UpdateLop(lop);
    }
}

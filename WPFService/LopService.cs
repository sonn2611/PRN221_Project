using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFRepo;

namespace WPFService
{
    public class LopService : ILopService
    {
        private LopRepository lopRepository = null;
        public LopService()
        {
            lopRepository = new LopRepository();
        }

        public bool AddLop(Lop lop) => lopRepository.AddLop(lop);

        public bool DeleteLop(string malop) => lopRepository.DeleteLop(malop);

        public List<Lop> GetAllLop() => lopRepository.GetAllLop();

        public Lop GetLopById(string malop) => lopRepository.GetLopById(malop);

        public List<Lop> SearchLopById(string id) => lopRepository.SearchLopById(id);

        public List<Lop> SearchLopByName(string name) => lopRepository.SearchLopByName(name);

        public bool UpdateLop(Lop lop) => lopRepository.UpdateLop(lop);

    }
}

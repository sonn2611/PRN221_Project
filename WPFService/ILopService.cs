using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;

namespace WPFService
{
    public interface ILopService
    {
        List<Lop> GetAllLop();
        Lop GetLopById(string malop);
        bool AddLop(Lop lop);
        bool UpdateLop(Lop lop);
        bool DeleteLop(string malop);
        List<Lop> SearchLopByName(string name);
        List<Lop> SearchLopById(string id);
    }
}

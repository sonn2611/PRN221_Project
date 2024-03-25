using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFDAO;

namespace WPFRepo
{
    public class DiemsvRepository : IDiemsvRepository
    {
        public bool AddDiemsv(Diemsv diemsv) => DiemsvDAO.Instance.AddDiemsv(diemsv);

        public bool DeleteDiemsv(string masv, string mamh) => DiemsvDAO.Instance.DeleteDiemsv(masv, mamh);

        public List<Diemsv> GetAllDiemsv() => DiemsvDAO.Instance.GetAllDiemsv();

        public Diemsv GetDiemsvById(string masv) => DiemsvDAO.Instance.GetDiemsvById(masv);

        public List<Diemsv> GetDiemsvByMasv(string masv) => DiemsvDAO.Instance.GetDiemsvByMasv(masv);

        public Diemsv GetDiemsvByMonhoc(string name) => DiemsvDAO.Instance.GetDiemsvByMonhoc(name);

        public List<Diemsv> GetTopDiemsv() => DiemsvDAO.Instance.GetTopDiemsv();

        public bool UpdateDiemsv(Diemsv diemsv) => DiemsvDAO.Instance.UpdateDiemsv(diemsv);
    }
}

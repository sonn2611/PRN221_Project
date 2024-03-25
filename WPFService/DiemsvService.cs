using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFRepo;

namespace WPFService
{
    public class DiemsvService : IDiemsvService
    {
        private IDiemsvRepository diemsvRepository = null;
        public DiemsvService()
        {
            diemsvRepository = new DiemsvRepository();
        }
        public bool AddDiemsv(Diemsv diemsv) => diemsvRepository.AddDiemsv(diemsv);

        public bool DeleteDiemsv(string masv, string mamh) => diemsvRepository.DeleteDiemsv(masv, mamh);

        public List<Diemsv> GetAllDiemsv() => diemsvRepository.GetAllDiemsv();

        public Diemsv GetDiemsvById(string masv) => diemsvRepository.GetDiemsvById(masv);

        public List<Diemsv> GetDiemsvByMasv(string masv) => diemsvRepository.GetDiemsvByMasv(masv);

        public Diemsv GetDiemsvByMonhoc(string name) => diemsvRepository.GetDiemsvByMonhoc(name);

        public List<Diemsv> GetTopDiemsv() => diemsvRepository.GetTopDiemsv();

        public bool UpdateDiemsv(Diemsv diemsv) => diemsvRepository.UpdateDiemsv(diemsv);

    }
}

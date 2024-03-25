using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Diemsv
    {
        public string Masv { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public double? Diem { get; set; }

        public virtual Monhoc MamhNavigation { get; set; } = null!;
        public virtual Sinhvien MasvNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Diemsvs = new HashSet<Diemsv>();
        }

        public string Mamh { get; set; } = null!;
        public string? Tenmh { get; set; }
        public int? Sotc { get; set; }

        public virtual ICollection<Diemsv> Diemsvs { get; set; }
    }
}

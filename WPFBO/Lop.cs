using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Lop
    {
        public string Malp { get; set; } = null!;
        public string? Tenlp { get; set; }
        public int? Nk { get; set; }

        public virtual Sinhvien? Sinhvien { get; set; }
    }
}

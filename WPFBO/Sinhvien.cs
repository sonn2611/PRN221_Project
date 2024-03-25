using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Sinhvien
    {
        public Sinhvien()
        {
            Accounts = new HashSet<Account>();
            Diemsvs = new HashSet<Diemsv>();
        }

        public string Masv { get; set; } = null!;
        public string? Tensv { get; set; }
        public string? Dcsv { get; set; }
        public string? Malp { get; set; }

        public virtual Lop? MalpNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Diemsv> Diemsvs { get; set; }
    }
}

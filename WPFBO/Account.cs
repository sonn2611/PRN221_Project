using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Role { get; set; }
        public string? Masv { get; set; }

        public virtual Sinhvien? MasvNavigation { get; set; }
    }
}

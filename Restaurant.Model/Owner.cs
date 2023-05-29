using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Owner
    {
        public string Fname { get; set; } = null!;

        public string Lname { get; set; } = null!;

        public string Contact { get; set; } = null!;

        public string RestName { get; set; } = null!;

        public virtual Restaurant RestNameNavigation { get; set; } = null!;
    }
}

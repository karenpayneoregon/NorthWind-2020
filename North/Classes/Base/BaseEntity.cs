using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North.Classes.Base
{
    public class BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string LastUser { get; set; }
        public bool? IsDeleted { get; set; }
    }

}

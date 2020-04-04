using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp_.Models
{
    public class openAccountModel
    {
        public Guid Id { get; set; }
        public string docmail { get; set; }
        public string usermail { get; set; }
        public bool isconf { get; set; }
        public DateTime confdate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models
{
    public class CustomerStorage
    {
        public int CustomerStorageId { get; set; }
        public int CustomerId { get; set; }
        public int StorageId { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }

        public Customer Customer { get; set; }
        public Storage Storage { get; set; }
    }
}

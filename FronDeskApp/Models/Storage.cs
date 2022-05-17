using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models
{
    public class Storage
    {
        public int StorageId { get; set; }
        public int StorageTypeId { get; set; }
        public int Row { get; set; }

        public StorageType StorageType { get; set; }
    }
}

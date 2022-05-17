using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models.Repositories
{
    public interface IStorageRepository
    {
        IEnumerable<Storage> All { get; }
        IEnumerable<StorageType> GetStorageTypes();
        IEnumerable<Storage> GetStorageByType(int storageType);
    }
}

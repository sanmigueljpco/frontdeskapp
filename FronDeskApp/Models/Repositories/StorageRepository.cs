using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly AppDbContext context;

        public StorageRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Storage> All
        {
            get
            {
                return context.Storages.Include(x => x.StorageType).ToList();
            }
        }

        public IEnumerable<Storage> GetStorageByType(int storageTypeId)
        {
            return context.Storages
                .Where(x => x.StorageTypeId == storageTypeId)
                .OrderBy(x => x.StorageId)
                .ToList();
        }

        public IEnumerable<StorageType> GetStorageTypes()
        {
            return context.StorageTypes.ToList();
        }
    }
}

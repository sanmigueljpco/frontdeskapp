using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomerStorage(Customer customer, int storageId);
        void ClaimCustomerStorage(int customerStorageId);
        IEnumerable<CustomerStorage> GetAllCustomerStorage();
        IEnumerable<CustomerStorage> GetStorageCurrentlyInUse();
    }
}

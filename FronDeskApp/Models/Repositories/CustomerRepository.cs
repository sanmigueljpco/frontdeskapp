using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void ClaimCustomerStorage(int customerStorageId)
        {
            var record = context.CustomerStorages.Find(customerStorageId);

            if (record != null)
            {
                record.Out = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void CreateCustomerStorage(Customer customer, int storageId)
        {
            context.Customers.Add(customer);
            context.CustomerStorages.Add(new CustomerStorage
            {
                CustomerId = customer.CustomerId,
                In = DateTime.Now,
                StorageId = storageId
            });

            context.SaveChanges();

        }

        public IEnumerable<CustomerStorage> GetAllCustomerStorage()
        {
            return context.CustomerStorages
                .Include(x => x.Customer)
                .Include(x => x.Storage)
                .ToList();
        }

        public IEnumerable<CustomerStorage> GetStorageCurrentlyInUse()
        {
            return context.CustomerStorages
                .Where(x => x.Out == null)
                .ToList();
        }
    }
}

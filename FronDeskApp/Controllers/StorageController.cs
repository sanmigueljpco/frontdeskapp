using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronDeskApp.Models.Repositories;
using FronDeskApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FronDeskApp.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageRepository storageRepository;
        private readonly ICustomerRepository customerRepository;

        public StorageController(IStorageRepository storageRepository, ICustomerRepository customerRepository)
        {
            this.storageRepository = storageRepository;
            this.customerRepository = customerRepository;
        }

        public IActionResult CheckAvailableStorage()
        {
            return View();
        }

        public JsonResult GetAvailableStorage()
        {
            var usedStorages = customerRepository.GetStorageCurrentlyInUse();
            var smallStorages = storageRepository.GetStorageByType(1);
            var mediumStorages = storageRepository.GetStorageByType(2);
            var lasrgeStorages = storageRepository.GetStorageByType(3);

            return Json(new AvailableStorageViewModel {
                Small = smallStorages.Where(x => usedStorages.All(y => y.StorageId != x.StorageId)).Count(),
                Medium = mediumStorages.Where(x => usedStorages.All(y => y.StorageId != x.StorageId)).Count(),
                Large = lasrgeStorages.Where(x => usedStorages.All(y => y.StorageId != x.StorageId)).Count()
            });
        }
    }
}
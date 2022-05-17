using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronDeskApp.Models;
using FronDeskApp.Models.Repositories;
using FronDeskApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FronDeskApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IStorageRepository storageRepository;

        public CustomerController(ICustomerRepository customerRepository, IStorageRepository storageRepository)
        {
            this.customerRepository = customerRepository;
            this.storageRepository = storageRepository;
        }

        public IActionResult CheckIn()
        {
            return View(new CheckInViewModel {
                StorageTypes = GetStorageTypes()
            });
        }

        [HttpPost]
        public IActionResult CheckIn(CheckInViewModel model)
        {
            var storages = storageRepository.GetStorageByType(model.StorageTypeId);
            var customerStorages = customerRepository.GetStorageCurrentlyInUse();

            var available = storages.Where(x => customerStorages.All(y => y.StorageId != x.StorageId))
                .Select(x => x.StorageId)
                .ToList();

            if (available.Count == 0)
            {
                ModelState.AddModelError(String.Empty, "There is no vacant space for your selected storage.");
            }

            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Firtname = model.Firstname,
                    Lastname = model.Lastname,
                    Phone = model.Phone
                };

                customerRepository.CreateCustomerStorage(customer, available.Min());

                return RedirectToAction("ListCustomerStorage");
            }

            model.StorageTypes = GetStorageTypes();

            return View(model);
        }

        public IActionResult ListCustomerStorage()
        {
            return View(customerRepository.GetAllCustomerStorage());
        }

        public IActionResult ClaimPackage(int id)
        {
            customerRepository.ClaimCustomerStorage(id);

            return RedirectToAction("ListCustomerStorage");
        }

        public List<SelectListItem> GetStorageTypes()
        {
            return storageRepository.GetStorageTypes()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.StorageTypeId.ToString()
                }).ToList();
        }
    }
}
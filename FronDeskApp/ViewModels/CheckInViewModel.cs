using FronDeskApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.ViewModels
{
    public class CheckInViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid phone number")]
        [Display(Name = "Phone number")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Please select storage size")]
        [Display(Name = "Storage Size")]
        public int StorageTypeId { get; set; }

        public List<SelectListItem> StorageTypes { get; set; }
    }
}

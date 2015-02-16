﻿using System.ComponentModel.DataAnnotations;

namespace Aluminum.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(254)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
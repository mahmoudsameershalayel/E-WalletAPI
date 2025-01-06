using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Infrastructure.DTOs.AuthDTOs
{
    public class UserForRegisterDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone1 { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone2 { get; set; }

        public string? Address { get; set; }

        public string? LocationLong { get; set; }

        public string? LocationLat { get; set; }
    }
}

using MG.Auth.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MG.Auth.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        [Required]
        public bool IsITAdmin { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        public BloodType BloodType { get; set; }

        [Required]
        public RestType RestType { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostNo { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

#nullable enable
        public string? EmergencyContactNumber { get; set; }
#nullable disable

        // For Joining other tables
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int JobPositionId { get; set; }
    }
}
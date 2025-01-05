using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionSetUp.models
{
    public partial class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? RollNo { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}

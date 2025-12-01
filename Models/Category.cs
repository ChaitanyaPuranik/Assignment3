using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProductRegistration_Group.Models;

public partial class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string CategoryName { get; set; } = null!;
    }  
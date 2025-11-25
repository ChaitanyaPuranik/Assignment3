using System;
using System.Collections.Generic;

namespace ProductRegistration_Group.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;
}

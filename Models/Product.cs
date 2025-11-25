using System;
using System.Collections.Generic;

namespace ProductRegistration_Group.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int CategoryId { get; set; }
}

using System;
using System.Collections.Generic;

namespace DbFirst1.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Age { get; set; }
}

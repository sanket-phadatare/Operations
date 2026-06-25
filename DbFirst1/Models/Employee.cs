using System;
using System.Collections.Generic;

namespace DbFirst1.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public int Salary { get; set; }
}

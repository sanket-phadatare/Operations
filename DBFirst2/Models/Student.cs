using System;
using System.Collections.Generic;

namespace DBFirst2.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Age { get; set; }

    public string MobileNumber { get; set; } = null!;
}

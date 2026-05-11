using System;
using System.Collections.Generic;

namespace JWTWithCoreApis.Models;

public partial class TblstudentDetail
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public string? EmailAddress { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public partial class StoreLocation
{
    [Key]
    public int LocationId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string Address { get; set; } = null!;
}
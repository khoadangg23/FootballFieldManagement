using System;
using System.Collections.Generic;

namespace FootballFieldManagement.Models;

public partial class Field
{
    public int FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? FieldType { get; set; }

    public decimal PricePerHour { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
}

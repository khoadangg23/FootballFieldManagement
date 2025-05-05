using System;
using System.Collections.Generic;

namespace FootballFieldManagement.Models;

public partial class BookingDetail
{
    public int BookingDetailId { get; set; }

    public int BookingId { get; set; }

    public int FieldId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int DurationHours { get; set; }

    public decimal PriceApplied { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Field Field { get; set; } = null!;
}

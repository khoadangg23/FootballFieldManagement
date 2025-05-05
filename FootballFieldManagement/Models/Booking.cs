using System;
using System.Collections.Generic;

namespace FootballFieldManagement.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly BookingDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;
}

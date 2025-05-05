﻿using System;
using System.Collections.Generic;

namespace FootballFieldManagement.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentMethod { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

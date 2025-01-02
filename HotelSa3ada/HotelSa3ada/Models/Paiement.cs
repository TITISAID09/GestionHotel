using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Paiement
{
    public int IdPaiement { get; set; }

    public double Montant { get; set; }

    public DateOnly DatePaiement { get; set; }

    public string ModePaiement { get; set; } = null!;

    public int IdReservation { get; set; }

    public virtual Reservation IdReservationNavigation { get; set; } = null!;
}

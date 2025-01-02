using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Reservation
{
    public int IdReservation { get; set; }

    public DateOnly DateDebut { get; set; }

    public DateOnly DateFin { get; set; }

    public int IdChambre { get; set; }

    public int IdClient { get; set; }

    public string Statut { get; set; } = null!;

    public virtual Chambre IdChambreNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}

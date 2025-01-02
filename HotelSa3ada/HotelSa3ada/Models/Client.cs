using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public virtual ICollection<Fidelite> Fidelites { get; set; } = new List<Fidelite>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Chambre
{
    public int Numero { get; set; }

    public string Type { get; set; } = null!;

    public double Prix { get; set; }

    public bool Disponible { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

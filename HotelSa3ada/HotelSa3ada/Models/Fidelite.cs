using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Fidelite
{
    public int IdFidelite { get; set; }

    public int Points { get; set; }

    public string Niveau { get; set; } = null!;

    public int IdClient { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;
}

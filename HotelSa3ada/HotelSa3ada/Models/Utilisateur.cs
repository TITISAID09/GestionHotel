using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Rapport> Rapports { get; set; } = new List<Rapport>();
}

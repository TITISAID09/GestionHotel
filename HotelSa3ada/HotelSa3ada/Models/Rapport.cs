using System;
using System.Collections.Generic;

namespace HotelSa3ada.Models;

public partial class Rapport
{
    public int IdRapport { get; set; }

    public DateOnly DateGeneration { get; set; }

    public string Contenu { get; set; } = null!;

    public int IdUtilisateur { get; set; }

    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class MonnaieMod
{

    public string? devise { get; set; }

    public Guid utilisateurId { get; set; }

    public string? libelle { get; set; }

    public bool estLocal { get; set; } = false;

    public DateTime created { get; set; } = DateTime.Now;

}

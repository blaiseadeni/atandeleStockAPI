﻿using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class EmballageMod
{

    public string? libelle { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime created { get; set; } = DateTime.Now;
}

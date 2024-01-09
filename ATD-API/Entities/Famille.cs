using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class Famille
{
    public Guid id { get; set; }

    public Guid utilisateurId { get; set; }

    public string? libelle { get; set; }

    public DateTime created { get; set; }

    [NotMapped]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}

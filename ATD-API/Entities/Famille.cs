using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class Famille
{
    public Guid Id { get; set; }

    public string? Libelle { get; set; }

    public DateTime Created { get; set; }

    [NotMapped]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}

﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistentLayer.Models;

public record Column(int Id = default, string TrelloId = null!, string Title = null!)
{
    public virtual IEnumerable<Experiment>? Experiments { get; set; }

    [NotMapped]
    public virtual IEnumerable<int>? ExperimentsIds { get; set; }
}
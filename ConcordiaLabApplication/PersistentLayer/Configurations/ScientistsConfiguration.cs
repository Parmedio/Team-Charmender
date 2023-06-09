﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistentLayer.Models;

namespace PersistentLayer.Configurations;

public class ScientistsConfiguration : IEntityTypeConfiguration<Scientist>
{
    public void Configure(EntityTypeBuilder<Scientist> entity)
    {
        //entity.HasIndex(p => p.TrelloToken).IsUnique(true);
        //entity.HasIndex(p => p.TrelloMemberId).IsUnique(true);
        //entity.Property(p => p.TrelloToken).IsRequired(true);
        //entity.Property(p => p.TrelloMemberId).IsRequired(true);

        entity.HasData(
            new Scientist(Id: 1, TrelloToken: "ATTA5c0a0bf47c1be3f495ebb81c42316684ff55e1134be71c0eba2cbecdd0614558CDCC81F8", Name: "Alessandro Ferluga", TrelloMemberId: "5bf9f901921c336b20b29d25"),
            new Scientist(Id: 2, TrelloToken: "ATTAd93cf67ec0072d821ff32e199156a675ed9301feea0f899df160829b3f14082dAB1E41AD", Name: "Marco da Pieve", TrelloMemberId: "639c692ed850f6055714fd55"),
            new Scientist(Id: 3, TrelloToken: "ATTA408bebeedb9948e62a1e38c11691049bc07e9329984c3897908a0127279faa4956E9CC86", Name: "Gabriele Cecutti", TrelloMemberId: "6474f28f0d4924c1eaff2824")
            );
    }
}

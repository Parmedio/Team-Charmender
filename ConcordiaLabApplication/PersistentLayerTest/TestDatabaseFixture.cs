﻿using Microsoft.EntityFrameworkCore;

using PersistentLayer.Configurations;
using PersistentLayer.Models;


namespace PersistentLayerTest
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Data Source=Pax;Initial Catalog=ConcordiaLabTest;Integrated Security=true;TrustServerCertificate=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var scientists = new List<Scientist>
                        {
                            new Scientist { TrelloToken = "wfrf445eef344rf", TrelloMemberId = "3434fv", Name = "gabriele" },
                            new Scientist { TrelloToken = "wedecerfedef", TrelloMemberId = "324332d", Name = "marco" },
                            new Scientist { TrelloToken = "wwdwx2rycecee23", TrelloMemberId = "dcwd2323c", Name = "alessandro" }
                        };
                        context.Scientists.AddRange(scientists);
                        context.SaveChanges();

                        var labels = new List<Label>
                        {
                            new Label { TrelloId = "TrelloLabelId1", Title = "low priority" },
                            new Label { TrelloId = "TrelloLabelId2", Title = "medium priority" },
                            new Label { TrelloId = "TrelloLabelId3", Title = "high priority" }
                        };
                        context.Labels.AddRange(labels);
                        context.SaveChanges();

                        var experiments = new List<Experiment>
                        {
                            new Experiment { TrelloId = "TrelloId1", Title = "Experiment 1", Description = "This is experiment 1", ColumnId = 1, LabelId = 9, Scientists = scientists },
                            new Experiment { TrelloId = "TrelloId2", Title = "Experiment 2", Description = "This is experiment 2", ColumnId = 2, LabelId = 7, Scientists = scientists },
                            new Experiment { TrelloId = "TrelloId3", Title = "Experiment 3", Description = "This is experiment 3", ColumnId = 3, LabelId = 8, Scientists = scientists},
                            new Experiment { TrelloId = "TrelloId4", Title = "Experiment 4", Description = "This is experiment 4", ColumnId = 2, LabelId = 9, Scientists = scientists }
                        };
                        context.Experiments.AddRange(experiments);
                        context.SaveChanges();

                        var comments = new List<Comment>
                        {
                            new Comment { TrelloId = "TrelloIdComment1", Body = "This is the first comment.", Date = DateTime.Now.AddDays(-3), CreatorName = "Gabriele", ExperimentId = 1, ScientistId = 4},
                            new Comment { TrelloId = "TrelloIdComment2", Body = "This is the second comment.", Date = DateTime.Now.AddDays(-2), CreatorName = "Jane",ExperimentId = 2},
                            new Comment { TrelloId = "TrelloIdComment3", Body = "This is the third comment.", Date = DateTime.Now.AddDays(-1), CreatorName = "Mike",ExperimentId = 3 },
                            new Comment { TrelloId = null, Body = "This is the fourth comment.", Date = DateTime.Now, CreatorName = "Fin",ExperimentId = 3 }
                        };
                        context.Comments.AddRange(comments);
                        context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }

        internal ConcordiaDbContext CreateContext()
            => new(
                new DbContextOptionsBuilder<ConcordiaDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);

    }
}

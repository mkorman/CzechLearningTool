using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Models
{
    interface IWordsContext : IObjectContextAdapter, IDisposable
    {
        // Get a set of words from the database
        DbSet<Word> Words { get; set; }

        int SaveChanges();

        DbEntityEntry<Word> Entry (Word word);

    }
}

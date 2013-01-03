using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Models
{
    /// <summary>
    /// Model repository, where our Word model is stored.
    /// 
    /// Supports CRUD + find operations
    /// </summary>
    public interface IWordRepository : IDisposable
    {
        // Get a set of words from the database
        DbSet<Word> Words { get; set; }
        
        Word Find(int id);

        Word Create(Word word);

        Word Edit(Word word);

        DbSet Remove(Word word);

        DbSet Remove(int id);
    }
}

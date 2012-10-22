using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Models
{
    interface IWordRepository
    {
        DbSet GetAll();

        Word Find(int id);

        Word Create(Word word);

        Word Edit(Word word);

        DbSet Remove(Word word);
    }
}

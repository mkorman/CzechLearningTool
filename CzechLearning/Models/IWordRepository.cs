<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
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

=======
<<<<<<< HEAD
=======
>>>>>>> Started implementing IoC and DI
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Models
{
<<<<<<< HEAD
    interface IWordRepository
    {
        DbSet GetAll();

=======
    public interface IWordRepository : IDisposable
    {
        // Get a set of words from the database
        DbSet<Word> Words { get; set; }
        
>>>>>>> Started implementing IoC and DI
        Word Find(int id);

        Word Create(Word word);

<<<<<<< HEAD
        Word Edit(Word word);

        DbSet Remove(Word word);
    }
}
=======
﻿using System;
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
>>>>>>> 7986f23947b753a85cf002f2b9590dd40d085722
>>>>>>> 41b5c4a05187924f46d64c6bfc4c4bdcc545adc5
=======
        void Edit(Word word);

        void Remove(Word word);

        void Remove(int id);
    }
}
>>>>>>> Started implementing IoC and DI

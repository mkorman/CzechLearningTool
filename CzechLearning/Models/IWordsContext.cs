<<<<<<< HEAD
﻿using System;
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

=======
<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> 7986f23947b753a85cf002f2b9590dd40d085722
>>>>>>> 41b5c4a05187924f46d64c6bfc4c4bdcc545adc5

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

<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using System;
using System.Collections.Generic;
using System.Data;
>>>>>>> Started implementing IoC and DI
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CzechLearning.Models
{
    public class WordRepository : IWordRepository
    {

        protected readonly CzechLearningContext context;

<<<<<<< HEAD
=======
        public WordRepository() : this (new CzechLearningContext ())
        {

        }


>>>>>>> Started implementing IoC and DI
        public WordRepository(CzechLearningContext context)
        {
            this.context = context;
        }

<<<<<<< HEAD

        public DbSet GetAll()
        {
            return context.Words;
        }
=======
        /*
        public DbSet<Word> GetAll()
        {
            return context.Words;
        }
         * */

        public DbSet<Word> Words
        {
            get { return context.Words; }
            set { context.Words = value; }
        }
>>>>>>> Started implementing IoC and DI

        public Word Find(int id)
        {
            return context.Words.Find (id);
        }

        public Word Create(Word word)
        {
            return context.Words.Add(word);
        }


<<<<<<< HEAD
        public Word Edit(Word word)
        {
            //return context.Words.ed
        }

    }
=======
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CzechLearning.Models
{
    public class WordRepository : IWordRepository
    {

        protected readonly CzechLearningContext context;

        public WordRepository(CzechLearningContext context)
        {
            this.context = context;
        }


        public DbSet GetAll()
        {
            return context.Words;
        }

        public Word Find(int id)
        {
            return context.Words.Find (id);
        }

        public Word Create(Word word)
        {
            return context.Words.Add(word);
        }


        public Word Edit(Word word)
        {
            //return context.Words.ed
        }

    }
>>>>>>> 7986f23947b753a85cf002f2b9590dd40d085722
=======
        public void Edit(Word word)
        {
            context.Entry(word).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Remove(int id)
        {
            Word word = context.Words.Find(id);
            Remove(word);
        }

        public void Remove(Word word)
        {
            context.Words.Remove(word);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
>>>>>>> Started implementing IoC and DI
}
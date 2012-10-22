<<<<<<< HEAD
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
}
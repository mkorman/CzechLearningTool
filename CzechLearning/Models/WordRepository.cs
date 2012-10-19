using System;
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
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CzechLearning.Models
{
    public class WordRepository : IWordRepository
    {

        protected readonly CzechLearningContext context;

        public WordRepository() : this (new CzechLearningContext ())
        {
        }

        public WordRepository(CzechLearningContext context)
        {
            this.context = context;
        }

        public DbSet<Word> Words
        {
            get { return context.Words; }
            set { context.Words = value; }
        }

        // used to be public DbSet<Word>, but not necessary
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
             context.Words.Add(word);
             context.SaveChanges();
             return word;
        }

        public Word Edit(Word word)
        {
            context.Entry(word).State = EntityState.Modified;
            context.SaveChanges();
            return word;
        }

        public DbSet Remove(int id)
        {
            Word word = context.Words.Find(id);
            return Remove(word);
        }

        public DbSet Remove(Word word)
        {
            context.Words.Remove(word);
            context.SaveChanges();
            return context.Words;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
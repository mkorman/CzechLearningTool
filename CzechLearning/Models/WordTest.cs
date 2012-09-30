using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CzechLearning.Models
{
    /// <summary>
    /// Wraps around a 'word' object and allows the user to guess the translation
    /// 
    /// Contains validation to verify that the translation is OK.
    /// </summary>
    public class WordTest :  IValidatableObject
    {

        protected readonly Word word;

        [Required]
        public String userTranslation {get; set;}
        public String English { get { return word.English; } set { word.English = value; } }
        public String Czech { get { return word.Czech; } set { word.Czech = value; } }

        public WordTest()
        {
            word = new Word ();
            userTranslation = "";
        }

        public WordTest(Word word)
        {
            this.word = word;
            this.userTranslation = "";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            // Will validate if the user successfully translated the word into Czech

            if (!userTranslation.Equals(Czech))
            {
                yield return new ValidationResult("Wrong translation", new [] {"userTranslation"});
            }
        }
    }
}
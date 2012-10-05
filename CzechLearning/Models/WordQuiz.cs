using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning.Models
{
    /// <summary>
    /// Wraps around a 'word' object and allows the user to guess the translation
    /// 
    /// Contains validation to verify that the translation is OK.
    /// </summary>
    public class WordQuiz :  IValidatableObject
    {
        protected static CultureInfo myCulture = CultureInfo.CreateSpecificCulture ("cs-CZ");
        protected readonly Word word;

        [Required]
        [DisplayName("Translation")]
        public String userTranslation {get; set;}
        [HiddenInput]
        public String English { get { return word.English; } set { word.English = value; } }
        public String Czech { get { return word.Czech; } set { word.Czech = value; } }

        public WordQuiz()
        {
            word = new Word ();
            userTranslation = "";
        }

        public WordQuiz(Word word)
        {
            this.word = word;
            this.userTranslation = "";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            // Will validate if the user successfully guessed the Czech translation

            if (String.Compare (userTranslation,Czech,true, myCulture) != 0)
            {
                yield return new ValidationResult("Wrong translation", new [] {"userTranslation"});
            }
        }
    }
}
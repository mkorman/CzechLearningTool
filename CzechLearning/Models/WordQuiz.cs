using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
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
        public String English { get { return word.English; } set { word.English = value; } }
        [HiddenInput]
        public String Czech { get { return word.Czech; } set { word.Czech = value; } }
        [HiddenInput]
        public int hintLevel { get; set; }

        public WordQuiz() : this (new Word ())
        {
        }

        public WordQuiz(Word word)
        {
            this.word = word;
            this.userTranslation = String.Empty;
            this.hintLevel = 0;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            // Will validate if the user successfully guessed the Czech translation

            if (String.Compare (userTranslation,Czech,true, myCulture) != 0)
            {
                yield return new ValidationResult("Wrong translation", new [] {"userTranslation"});
            }
        }

        /// <summary>
        /// Provides some hint into the word translation.
        /// It progressively increases with differing hint levels
        /// The hint is written to the userTranslation, ready to be rendered
        /// </summary>
        public void Hint()
        {
            // Increase hint level, up to the word length
            hintLevel = Math.Min(++hintLevel, Czech.Length);

            var sb = new StringBuilder();

            // Provide the first 'hintLevel' characters
            for (int i = 0; i < hintLevel; i++)
            {
                sb.Append (Czech[i]);    
            }

            // Provide the rest as asterisks
            for (int i = hintLevel; i < Czech.Length; i++)
            {
                sb.Append('*');
            }

            userTranslation = sb.ToString();
        }

    }
}
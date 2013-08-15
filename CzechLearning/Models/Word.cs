using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CzechLearning.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public String English { get; set; }
        public String Czech { get; set; }

        public override bool Equals (object obj)
        {
            if (!(obj is Word))
            {
                return false;
            }

            var that = (Word)obj;
            return (this.Czech == that.Czech) && (this.English == that.English);
        }
    }
}
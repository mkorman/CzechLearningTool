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
    }
}
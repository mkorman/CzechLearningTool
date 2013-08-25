using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Models
{
    public interface IRandomWordProvider
    {
        /// <summary>
        /// Gets a random word
        /// </summary>
        /// <returns>A random word</returns>
        Word GetNext();
    }
}

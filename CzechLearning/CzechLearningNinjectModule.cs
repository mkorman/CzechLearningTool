<<<<<<< HEAD
﻿using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CzechLearning
{
    /// <summary>
    /// A Ninject module designed to inject dependencies in our CzechLearning application
    /// </summary>
    public class CzechLearningNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWordsContext>().To<CzechLearningContext>();
        }
    }
=======
﻿using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CzechLearning
{
    /// <summary>
    /// A Ninject module designed to inject dependencies in our CzechLearning application
    /// </summary>
    public class CzechLearningNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWordsContext>().To<CzechLearningContext>();
        }
    }
>>>>>>> 7986f23947b753a85cf002f2b9590dd40d085722
}
using CzechLearning.Controllers;
using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning
{
    /// <summary>
    /// This class is responsible for instantiating Controllers.
    /// 
    /// From here we can locate (service locator antipattern) or inject (dependency injection pattern) 
    /// our own controllers as required
    /// 
    /// This would be a great place for ninject to start injecting stuff
    /// </summary>
    public class CzechControllerActivator : IControllerActivator
    {
        IController IControllerActivator.Create(System.Web.Routing.RequestContext requestcontext, Type controllerType)
        {
            if (controllerType.Equals (typeof (WordController)))
            {
                return new WordController (new CzechLearningContext ());
            }

            return Activator.CreateInstance (controllerType) as IController;
        }
    }
}
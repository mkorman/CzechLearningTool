using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning
{
    public class CzechDependencyResolver : IDependencyResolver
    {

        public CzechDependencyResolver()
        {
        }


        public object GetService(Type serviceType)
        {
            /*
            if (serviceType.Equals(typeof(WordController)))
            {
                return new WordController(new CzechLearningContext ());
            }
            

            if (serviceType.Equals (typeof (IControllerActivator)))
            {
                return new CzechControllerActivator ();
            }
            */

            return null;
            
        }


        /// <summary>
        /// We don't want to hook anything, so we just return an empty list
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<Object>();
        }

    }

}
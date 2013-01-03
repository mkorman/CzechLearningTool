<<<<<<< HEAD
<<<<<<< HEAD
﻿using CzechLearning.Controllers;
using CzechLearning.Models;
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
            */

            if (serviceType.Equals (typeof (IControllerActivator)))
            {
                return new CzechControllerActivator ();
            }

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

=======
<<<<<<< HEAD
=======
>>>>>>> Committing to repo to catch up
﻿using CzechLearning.Controllers;
using CzechLearning.Models;
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
            */
<<<<<<< HEAD

            if (serviceType.Equals (typeof (IControllerActivator)))
            {
                return new CzechControllerActivator ();
            }

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
=======
﻿using CzechLearning.Controllers;
using CzechLearning.Models;
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
            */

=======
            /*
>>>>>>> Committing to repo to catch up
            if (serviceType.Equals (typeof (IControllerActivator)))
            {
                return new CzechControllerActivator ();
            }
<<<<<<< HEAD

=======
            */
>>>>>>> Committing to repo to catch up
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
<<<<<<< HEAD
>>>>>>> 7986f23947b753a85cf002f2b9590dd40d085722
>>>>>>> 41b5c4a05187924f46d64c6bfc4c4bdcc545adc5
=======
>>>>>>> Committing to repo to catch up
}
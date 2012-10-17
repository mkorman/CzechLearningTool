using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning
{
    /// <summary>
    /// Allows us to use more than one submit button in a form.
    /// 
    /// Usage:
    /// 
    /// Decorate a controller method with:
    /// [MultiButton(MatchFormKey = "action", MatchFormValue = "Create")] 
    /// 
    /// Add submit buttons to a form as follows:
    ///   <input type="submit" value="Cancel" name="action" />
    ///   <input type="submit" value="Create" name="action" /> 
    /// 
    /// Taken from: http://blog.maartenballiauw.be/post/2009/11/26/Supporting-multiple-submit-buttons-on-an-ASPNET-MVC-view.aspx
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultiButtonAttribute : ActionNameSelectorAttribute
    {
        public string MatchFormKey { get; set; }
        public string MatchFormValue { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request[MatchFormKey] != null &&
                controllerContext.HttpContext.Request[MatchFormKey] == MatchFormValue;
        }
    }
}
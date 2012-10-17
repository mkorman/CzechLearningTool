using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning
{
    
    /// TODO: there's a more elegant solution here:
    /// http://blog.maartenballiauw.be/post/2009/11/26/Supporting-multiple-submit-buttons-on-an-ASPNET-MVC-view.aspx
    /// 
    /// <summary>
    /// This attribute is used to decorate actions in a Controller, and allows us to discriminate what controller to use
    /// depending on an attribute in the calling button.
    /// 
    /// This can be quite useful to, for instance, create more than 1 submit button for a form, each pointing to a different
    /// Action.
    /// 
    /// To do this, follow these steps:
    /// 
    /// - Decorate your controller methods with this attribute, and supply an action name
    /// - Ensure that your form points to that action name
    /// - Ensure that your submit button's 'name' attribute equals the actual method name
    /// 
    /// Idea taken from: http://blog.ashmind.com/2010/03/15/multiple-submit-buttons-with-asp-net-mvc-final-solution/
    /// </summary>
    public class HttpParamActionAttribute : ActionNameSelectorAttribute
    {
        public const string ACTION_NAME = "Action";

        protected string methodActionName = ACTION_NAME;

        /// <summary>
        /// Default constructor
        /// </summary>
        public HttpParamActionAttribute () : this (ACTION_NAME)
        {
        }

        /// <summary>
        /// Constructior, indicating the action name
        /// </summary>
        /// <param name="methodActionName"></param>
        public HttpParamActionAttribute(string methodActionName)
        {
            this.methodActionName = methodActionName;
        }

        /// <summary>
        /// This actually does the method dispatch
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="actionName"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            String methodName = methodInfo.Name;

            // If the action name equals the method, we got a match :)
            if (actionName.Equals(methodName, StringComparison.InvariantCultureIgnoreCase))
                return true;

            // Action name must match our defined action name (passed in the constructor)..
            if (!actionName.Equals(methodActionName, StringComparison.InvariantCultureIgnoreCase))
                return false;

            // ... and the request has to have an attribute named as the method name
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request[methodName] != null;
        }
    }
}
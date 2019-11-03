using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace RailwayService.Helper
{
    /// <summary>
    /// Handle Exception
    /// </summary>
    public class HandleException : ExceptionFilterAttribute
    {
        /// <summary>
        /// Error Handler for service
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {            
            //We can log this exception message to the file or database for support.  
            //Right now I am just sending the internal server error to client

            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error.Please Contact your Administrator.")
            }; 
        }
    }
}

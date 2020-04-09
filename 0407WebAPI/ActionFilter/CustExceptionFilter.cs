using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using NLog;
using _0407WebAPI.Models;

namespace _0407WebAPI.ActionFilter
{
    public class CustExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception != null)
            {
                if (actionExecutedContext.Exception is System.Web.Http.HttpResponseException)
                {
                    var exResponse = ((System.Web.Http.HttpResponseException)actionExecutedContext.Exception).Response; exceptionMessage = exResponse.ReasonPhrase;
                }
                else { exceptionMessage = actionExecutedContext.Exception.Message; }
            }
            Logger _logger = NLog.LogManager.GetLogger("Api");
            _logger.Error($"{DateTime.Now.ToString() }-exception-{exceptionMessage}");

            CustHttpResponseMessage custHttp = new CustHttpResponseMessage();
            actionExecutedContext.Response = custHttp.GetFailMessage("CUst FAIL", exceptionMessage);

        }
    }
}
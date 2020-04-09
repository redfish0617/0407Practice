using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace _0407WebAPI.Models
{
    public class CustHttpResponseMessage
    {
        public HttpResponseMessage GetSuccessMessage(string phaseName, string content)
        {
            HttpResponseMessage resMessge = new HttpResponseMessage();
            resMessge.StatusCode = HttpStatusCode.OK;
            if (!string.IsNullOrEmpty(phaseName))
            {
                resMessge.ReasonPhrase = phaseName;
            }
            resMessge.Content = new StringContent(content);
            return resMessge;
        }
        public HttpResponseMessage GetFailMessage(string phaseName, string content)
        {
            HttpResponseMessage resMessge = new HttpResponseMessage();
            resMessge.StatusCode = HttpStatusCode.ExpectationFailed;
            if (!string.IsNullOrEmpty(phaseName))
            {
                resMessge.ReasonPhrase = phaseName;
            }
            resMessge.Content = new StringContent(content);
            return resMessge;
        }
    }

}
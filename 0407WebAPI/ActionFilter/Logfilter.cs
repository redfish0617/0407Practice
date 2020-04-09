using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using System.Text;

namespace _0407WebAPI.ActionFilter
{
    public abstract class Logfilter : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {           
            //執行前
            var requestMessage = await request.Content.ReadAsByteArrayAsync();
            await IncommingMessageAsync(requestMessage);

            var response = await base.SendAsync(request, cancellationToken);
            //執行後
            byte[] responseMessage;
            if (response.Content != null)
            {
                responseMessage = await response.Content.ReadAsByteArrayAsync();
            }
            else
            {
                responseMessage = null;
            }
            await OutgoingMessageAsync(responseMessage);
            return response;
        }
        //Request 進入時 
        protected abstract Task IncommingMessageAsync(byte[] message);
        //Response 離開時 
        protected abstract Task OutgoingMessageAsync(byte[] message);
    }
    public class MessageLoggingHandler : Logfilter
    {
        protected override async Task IncommingMessageAsync(byte[] message)
        {
            await Task.Run(() =>
            {
                string m = string.Empty; if (message != null) m = Encoding.UTF8.GetString(message); // do logging
            });
        }
        protected override async Task OutgoingMessageAsync(byte[] message)
        {
            await Task.Run(() =>
            {
                string m = string.Empty; if (message != null) m = Encoding.UTF8.GetString(message); // do logging 
            });
        }

    }
}
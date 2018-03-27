using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure
{

    public class HttpException : Exception
    {
        public int StatusCode { get; set; }

        public object Body { get; set; }

        public HttpException()
        {

        }

        public HttpException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpException(int statusCode, object body)
        {
            this.StatusCode = statusCode;
            this.Body = body;
        }
    }

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (HttpException e)
            {
                context.Response.StatusCode = e.StatusCode;
                if (e.Body != null)
                {
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(e.Body, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
                }
            }
        }
    }
}

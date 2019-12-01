using ExamTask.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace ExamTask.API.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandlValidationExceptionAsync(context, ex);
            }
        }

        private Task HandlValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var internalErrorCode = exception.ValidationCode;

            switch (exception)
            {
                case ValidationException e:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                InternalErrorCode = internalErrorCode
            }));
        }
    }
}

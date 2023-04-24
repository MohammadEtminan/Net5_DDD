using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnLineStore.WebApi.Middlewares.ApiExceptionHandlers;

namespace OnLineStore.WebApi.Middlewares.ApiExceptionHandler
{
    public class ApiExceptionMiddleware
    {
        #region [- ctor -]
        public ApiExceptionMiddleware()
        {

        }
        #endregion

        #region [- props -]
        public RequestDelegate Next { get; set; }
        public ILogger<ApiExceptionMiddleware> Logger { get; set; }
        #endregion

        #region [- Invoke(HttpContext httpContext) -]
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExeptionAsync(httpContext, ex);
            }
        }
        #endregion

        #region [- HandleExeptionAsync(HttpContext context, Exception exception) -]
        private Task HandleExeptionAsync(HttpContext context, Exception exception)
        {
            var error = new ApiError
            {
                Id = Guid.NewGuid().ToString(),
                Status = (short)HttpStatusCode.InternalServerError,
                Title = "Something wrong..."
            };

            var innerExeptionMessage = GetInnermostExceptionMessage(exception);

            var level = LogLevel.Error;
            Logger.Log(level, exception, "Exception message is:" + innerExeptionMessage + "-- {ErrorId}.", error.Id);

            var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
        #endregion

        #region [- GetInnermostExceptionMessage(Exception exception) -]
        private string GetInnermostExceptionMessage(Exception exception)
        {
            if (exception.InnerException != null)
            {
                return GetInnermostExceptionMessage(exception.InnerException);
            }
            else
            {
                return exception.Message;
            }
        }
        #endregion
    }
}
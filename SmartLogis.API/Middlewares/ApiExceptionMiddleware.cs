using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models.Middlewares;

namespace SmartLogis.API
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (ApiException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;

                var response = new
                {
                    status = ex.StatusCode,
                    message = ex.Message
                };
                await context.Response.WriteAsJsonAsync(response);
            } catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var response = new { status = 500, message = "Ocurrio un error inesperado" };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
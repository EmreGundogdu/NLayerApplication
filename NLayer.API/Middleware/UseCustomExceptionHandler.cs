using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Excepitons;
using System.Text.Json;

namespace NLayer.API.Middleware
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}

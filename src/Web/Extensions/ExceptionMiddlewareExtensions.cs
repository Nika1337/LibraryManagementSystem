using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Domain.Exceptions;
using System.Threading.Tasks;

namespace Nika1337.Library.Web.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    switch (contextFeature.Error)
                    {
                        case NotFoundException _:
                            context.Response.Redirect("/Home/NotFound");
                            break;
                        default:
                            context.Response.Redirect("/Home/Error");
                            break;
                    }

                    await Task.CompletedTask;
                }
            });
        });
    }
}

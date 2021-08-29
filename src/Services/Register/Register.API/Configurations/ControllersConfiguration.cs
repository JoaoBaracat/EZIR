using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Register.API.Configurations
{
    public static class ControllersConfiguration
    {
        public static void AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                setupAction.Filters.Add(
                    new ProducesDefaultResponseTypeAttribute());

                var jsonOutputFormatter = setupAction.OutputFormatters
                    .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }

                var jsonInputFormatter = setupAction.InputFormatters
                    .OfType<SystemTextJsonInputFormatter>().FirstOrDefault();
                if (jsonInputFormatter != null)
                {
                    if (jsonInputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonInputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            });
        }
    }
}
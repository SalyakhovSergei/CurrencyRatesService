using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace centros_ref_book.Discovery
{
    public class SwaggerDefaultValues : IOperationFilter, IDocumentFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;			
            operation.Deprecated |= apiDescription.IsDeprecated();
            operation.OperationId = apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;

            if (operation.Parameters == null)
                return;

			
            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                parameter.AllowEmptyValue = true;
                parameter.Required = false;
                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (parameter.Schema.Default == null && description.DefaultValue != null)
                {
                    parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
                }

                parameter.Required |= description.IsRequired;
            }
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            
        }
    }
}

public class ReApplyOptionalRouteParameterOperationFilter : IOperationFilter
{
    const string captureName = "routeParameter";

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var httpMethodAttributes = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute>();

        var httpMethodWithOptional = httpMethodAttributes?.FirstOrDefault(m => m.Template?.Contains("?") ?? false);
        if (httpMethodWithOptional == null)
            return;

        string regex = $"{{(?<{captureName}>\\w+)\\?}}";

        var matches = System.Text.RegularExpressions.Regex.Matches(httpMethodWithOptional.Template, regex);

        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            var name = match.Groups[captureName].Value;

            var parameter = operation.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Path && p.Name == name);
            if (parameter != null)
            {
                parameter.AllowEmptyValue = true;
                parameter.Description = "Must check \"Send empty value\" or Swagger passes a comma for empty values otherwise";
                parameter.Required = false;
                //parameter.Schema.Default = new OpenApiString(string.Empty);
                parameter.Schema.Nullable = true;
            }
        }
    }
}
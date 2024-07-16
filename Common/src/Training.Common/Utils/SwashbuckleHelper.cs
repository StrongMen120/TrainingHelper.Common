using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Training.Common.Utils;

public static class SwashbuckleHelper
{
    /// <summary>
    /// Documents enum without values that are marked as [Obsolete] or [NotMapped].
    /// </summary>
    /// <param name="options"> SwaggerGenOptions. </param>
    /// <typeparam name="TEnum"> Enum type. </typeparam>
    public static void MapAnnotatedEnum<TEnum>(this SwaggerGenOptions options)
        where TEnum : struct, Enum
    {
        var enumType = typeof(TEnum);

        bool IsEnumValueHidden(TEnum value)
        {
            var member = enumType?.GetMember(value.ToString()).FirstOrDefault(m => m.DeclaringType == enumType);
            var notMapped = member?.GetCustomAttributes<NotMappedAttribute>(false).FirstOrDefault() != default;
            var isObsolete = member?.GetCustomAttributes<ObsoleteAttribute>(false).FirstOrDefault() != default;

            return notMapped || isObsolete;
        }

        var correctValues = Enum.GetValues<TEnum>().Where(value => !IsEnumValueHidden(value));
        var exposedValues = correctValues.Select(value => new OpenApiString(value.ToString())).OfType<IOpenApiAny>().ToList();

        options.MapType(enumType, () => new OpenApiSchema()
        {
            Type = "string",
            Enum = exposedValues,
        });
    }

    public static class DocInclusionStrategy
    {
        public static Func<string, Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription, bool> Flexible { get; } = FlexibleStrategy;

        private static bool FlexibleStrategy(string version, Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription desc)
        {
            if (version == "all") return true;
            if (!desc.TryGetMethodInfo(out var method)) return false;

            var controllerAttributes = method.DeclaringType?.GetCustomAttributes() ?? Enumerable.Empty<Attribute>();
            var actionAttributes = method.GetCustomAttributes();

            var versions = controllerAttributes.OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
            var maps = actionAttributes.OfType<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();

            return versions.Any(v => $"v{v}" == version) && (!maps.Any() || maps.Any(v => $"v{v}" == version));
        }
    }
}

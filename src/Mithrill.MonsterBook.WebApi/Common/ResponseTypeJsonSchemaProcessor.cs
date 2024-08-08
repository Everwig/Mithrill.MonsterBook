using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NJsonSchema;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Mithrill.MonsterBook.WebApi.Common
{
    public class ResponseTypeJsonSchemaProcessor : IDocumentProcessor
    {
        private static readonly IEnumerable<ResponseTypeSetting> ResponseTypeSettings = new[]
        {
            new ResponseTypeSetting
            {
                SchemaName = nameof(ProblemDetails),
                PropertyExclusionSettings = new[]
                {
                    new ResponseTypeSetting.PropertyExclusionSetting
                    {
                        PropertyName = "extensions",
                        ExcludeFromParent = true
                    }
                }
            },
            new ResponseTypeSetting
            {
                SchemaName = nameof(ProblemDetailsWithTraceId),
                PropertyExclusionSettings = new[]
                {
                    new ResponseTypeSetting.PropertyExclusionSetting
                    {
                        PropertyName = "extensions",
                        ExcludeFromParent = true
                    }
                }
            }
        };

        public void Process(DocumentProcessorContext context)
        {
            foreach (var setting in ResponseTypeSettings)
            {
                if (TryToGetJsonSchemaFromDocumentProcessContextBySchemaName(context, setting.SchemaName, out var jsonSchema))
                {
                    ApplyPropertyExclusionSettingsOnJsonSchema(jsonSchema, setting.PropertyExclusionSettings);
                }
            }
        }

        private static void ApplyPropertyExclusionSettingsOnJsonSchema(
            JsonSchema jsonSchema,
            IEnumerable<ResponseTypeSetting.PropertyExclusionSetting> propertyExclusionSettings)
        {
            foreach (var setting in propertyExclusionSettings)
            {
                jsonSchema.Properties.Remove(setting.PropertyName);

                if (setting.ExcludeFromParent)
                {
                    foreach (var parentSchema in jsonSchema.AllInheritedSchemas)
                    {
                        parentSchema.Properties.Remove(setting.PropertyName);
                    }
                }
            }
        }

        private static bool TryToGetJsonSchemaFromDocumentProcessContextBySchemaName(
            DocumentProcessorContext context,
            string schemaName,
            out JsonSchema schema)
        {
            return context.Document.Components.Schemas.TryGetValue(schemaName, out schema);
        }

        private class ResponseTypeSetting
        {
            public string SchemaName { get; set; }

            public IReadOnlyCollection<PropertyExclusionSetting> PropertyExclusionSettings { get; set; }

            internal class PropertyExclusionSetting
            {
                public string PropertyName { get; set; }

                public bool ExcludeFromParent { get; set; }
            }
        }
    }
}
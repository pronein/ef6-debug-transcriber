using System.Data.Entity.ModelConfiguration.Configuration;

namespace EF6DebugTranscriber.Extensions {
    public static class PrimitivePropertyConfigurationExtensions {
        public static string DefaultAnnotationName = "DefaultValue";

        public static T Default<T>(this T config, object value) where T : PrimitivePropertyConfiguration {
            config.HasColumnAnnotation(DefaultAnnotationName, value);

            return config;
        }
    }
}

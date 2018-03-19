using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using AnnotationNames = EF6DebugTranscriber.Extensions.PrimitivePropertyConfigurationExtensions;

namespace EF6DebugTranscriber.Migrations {
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator {
        protected override void Generate(CreateTableOperation createTableOperation) {
            foreach (var col in createTableOperation.Columns)
                SetDefaultValue(col);

            base.Generate(createTableOperation);
        }

        protected override void Generate(AddColumnOperation addColumnOperation) {
            SetDefaultValue(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(AlterColumnOperation alterColumnOperation) {
            SetDefaultValue(alterColumnOperation.Column);

            base.Generate(alterColumnOperation);
        }

        private void SetDefaultValue(ColumnModel column) {
            var annotation = column.Annotations.ContainsKey(AnnotationNames.DefaultAnnotationName) ? column.Annotations[AnnotationNames.DefaultAnnotationName] : null;
            if (annotation != null) {
                column.DefaultValue = column.Annotations[AnnotationNames.DefaultAnnotationName].NewValue;
            }
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EF6DebugTranscriber.Extensions;

namespace EF6DebugTranscriber.Data.Entities.Maps {
    class GearEntityMap : EntityTypeConfiguration<GearEntity> {
        public GearEntityMap() {
            ToTable("Gear", "dbo");

            HasKey(g => g.Id);
            Property(g => g.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            Property(g => g.Weight)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .Default(1f);

            HasOptional(g => g.Container)
                .WithOptionalDependent();
        }
    }
}

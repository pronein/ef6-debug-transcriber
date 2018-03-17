using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6DebugTranscriber.Data.Entities.Maps {

    class HeroEntityMap : EntityTypeConfiguration<HeroEntity> {
        public HeroEntityMap() {
            ToTable("Heros", "dbo");

            HasKey(he => he.Id);
            Property(he => he.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(he => he.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
        }
    }
}

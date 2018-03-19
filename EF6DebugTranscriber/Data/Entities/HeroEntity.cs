using System.Collections.Generic;

namespace EF6DebugTranscriber.Data.Entities {
    public class HeroEntity {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GearEntity> Gear { get; set; }

        public HeroEntity() {
            Gear = new List<GearEntity>();
        }
    }
}

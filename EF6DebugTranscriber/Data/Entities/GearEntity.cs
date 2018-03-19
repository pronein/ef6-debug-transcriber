namespace EF6DebugTranscriber.Data.Entities {
    public class GearEntity {
        public long Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }

        public GearEntity Container { get; set; }
    }
}

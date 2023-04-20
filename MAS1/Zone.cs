namespace MAS1
{
    public class Zone : IGamePiece
    {
        public static List<Zone> Zones { get; set; } = new List<Zone>();

        private int _id;
        public int Id => _id;

        private DateTime _creationDate;
        public DateTime CreationDate => _creationDate;
        public List<Character> Characters { get; }

        private string _name;
        public string Name 
        { 
            get => _name;
            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }
                _name = value;
            }
        }
        public string? Description { get; set; }

        public List<Map> Maps { get; } //TODO czy to powinno być tak

        public Zone(string name, string? description)
        {
            int maxid = 0;
            foreach (Zone zone in Zones)
            {
                if (zone.Id > maxid) { maxid = zone.Id; }
            }
            _id = maxid + 1;
            _creationDate = DateTime.UtcNow;
            Characters = new List<Character>();
            Name = name;
            Description = description;
            Maps = new List<Map>();
            Zones.Add(this);
        }
    }
}

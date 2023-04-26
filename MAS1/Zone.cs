using System.Collections.ObjectModel;

namespace MAS2
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
                _name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public string? Description { get; set; }

        private List<Map> _maps; 

        public void AddMap(Map map)
        {
            if(map == null) { throw new ArgumentNullException(nameof(map)); }
            if (_maps.Contains(map)) { throw new Exception("Zone is already in this map"); }
            _maps.Add(map);
            if(map.GetZone(this.Name) != this) { map.AddZone(this); }
        }

        public ReadOnlyCollection<Map> Maps => _maps.AsReadOnly();

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
            _maps = new List<Map>();
            Zones.Add(this);
        }
    }
}

namespace MAS2.GamePieces
{
    public class Map : Item
    {
        private Dictionary<string, Zone> _zones { get; }

        public void AddZone(Zone zone)
        {
            if (_zones.ContainsKey(zone.Name)) { throw new Exception("Map already contains this zone"); }
            _zones.Add(zone.Name, zone);
            if (zone.Map == null) { zone.Map = (this); }
        }

        public Zone? GetZone(string name)
        {
            return _zones.GetValueOrDefault(name);
        }

        public List<string> GetZoneNames()
        {
            return _zones.Keys.ToList();
        }

        public List<Zone> Zones { get => _zones.Values.ToList(); }

        public int NumberOfZones => _zones.Count;

        public Map(
            string name,
            string? description,
            int value,
            List<Zone>? zones
            ) : base(
                name,
                0.01f,
                description,
                value,
                EquipmentType.Other)
        {
            _zones = new Dictionary<string, Zone>();
            if (zones != null)
            {
                foreach (Zone zone in zones)
                {
                    AddZone(zone);
                }
            }
        }
        private Map() : base("",0.0f,"",0,EquipmentType.Other) { }
    }
}

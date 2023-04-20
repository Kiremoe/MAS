namespace MAS1
{
    public class Map : Item
    {
        private Dictionary<string, Zone> _zones { get; }

        public void AddZone(Zone zone)
        {
            if(_zones.ContainsKey(zone.Name))
            {
                throw new Exception("Map already contains this zone");
            }
            _zones.Add(zone.Name, zone);
            if (!zone.Maps.Contains(this))
            {
                _zones.Add(zone.Name, zone);
            }
        }

        public Zone? GetZone(string name)
        {
            return _zones.GetValueOrDefault(name);
        }

        public List<string> GetZoneNames()
        {
            return _zones.Keys.ToList();
        }

        public int NumberOfZones => _zones.Count;

        public Map(
            string nameOfTarain,
            float weight,
            string? description,
            int value,
            Equipment? equipment,
            List<Zone> zones
            ) : base(
                "Map of "+ nameOfTarain,
                0.01f,
                description,
                value,
                equipment,
                EquipmentType.Other)
        {
            _zones = new Dictionary<string, Zone>();
            foreach ( Zone zone in zones )
            {
                _zones.Add(zone.Name, zone);
                if (!zone.Maps.Contains(this))
                {
                    _zones.Add(zone.Name, zone);
                }
            }
        }
    }
}

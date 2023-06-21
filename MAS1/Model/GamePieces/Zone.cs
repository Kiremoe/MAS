using System.Collections.ObjectModel;
using MAS2.Model;

namespace MAS2.GamePieces
{
    public class Zone : GamePiece
    {
        public List<Character> Characters { get; } = new List<Character>();

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

        private Map? _map;

        public Map? Map { get => _map; set {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }
                _map = value;
                if (value.GetZone(Name) != this) { value.AddZone(this); }
            } }

        private List<Campain> _campains = new List<Campain>();
        public IReadOnlyCollection<Campain> Campains => _campains.AsReadOnly();
        public void AddCampainToZoneCampainList(Campain campain)
        {
            if(campain.Equals(null) || Campains.Contains(campain)) { throw new ArgumentException("Illegal argument"); }
            else { _campains.Add(campain); if (!campain.ZoneList.Contains(this)) { campain.AddZoneToCampain(this); } }
        }

        private List<EnemiesZones> _ez = new List<EnemiesZones>();
        public IReadOnlyCollection<EnemiesZones> EnemiesZones => _ez.AsReadOnly();
        public void AddEnemyInstanceToZone(EnemiesZones ez) { if (!EnemiesZones.Contains(ez)) { _ez.Add(ez); } }
        public void RemoveEnemyInstanceToZone(EnemiesZones ez) { if (EnemiesZones.Contains(ez)) { _ez.Remove(ez); } }

        public Zone(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}

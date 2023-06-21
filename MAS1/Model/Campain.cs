using MAS2.GamePieces;
using MAS2.Users;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MAS2.Model
{
    public class Campain
    {
        public int Id { get; private set; }

        private DateTime _startDate;
        public DateTime StartDate { get { return _startDate; } }
        public DateTime? EndDate { get; set; }

        private GameMaster _gameMaster;
        public GameMaster GameMaster
        {
            get => _gameMaster;
        }

        private List<Player> _playerList { get; } = new List<Player>();
        public IReadOnlyCollection<Player> PlayerList => _playerList.AsReadOnly();
        public void AddPlayerToCampain(Player player)
        {
            if (_playerList.Contains(player))
            {
                throw new Exception("Player already in campain");
            }
            else
            {
                _playerList.Add(player);
            }
        }
        public void RemovePlayerFromCampain(Player player)
        {
            if (!_playerList.Contains(player))
            {
                throw new Exception("Player not in campain");
            }
            else
            {
                _playerList.Remove(player);
            }
        }

        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyCollection<Zone> ZoneList => _zones.AsReadOnly();
        public void AddZoneToCampain(Zone zone)
        {
            if (_zones.Contains(zone)) { throw new Exception("Campain already contains this zone"); }
            else { _zones.Add(zone); if (!zone.Campains.Contains(this)) { zone.AddCampainToZoneCampainList(this); } }
        }

        public Campain(GameMaster gameMaster) : this()
        {
            _gameMaster = gameMaster;
            gameMaster.Campain = this;
        }

        private Campain()
        {
            _startDate = DateTime.UtcNow;
            EndDate = null;
        }
    }
}

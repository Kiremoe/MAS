using MAS2.Model;
using MAS2.Users;

namespace MAS2.GamePieces
{
    public class Player : Character
    {

        private User _user;
        public User User { get { return _user; } set { if (value.Equals(null)) { throw new ArgumentNullException(nameof(value)); } else { _user = value; } } }
        public int UserId { get; }

        public Player(string name, Zone zone, User user) : base(name, zone)
        {
            _user = user;
            UserId = _user.Id;

        }

        private Player() : base("", new Zone("", "")) { }

        public Campain? Campain { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }
}

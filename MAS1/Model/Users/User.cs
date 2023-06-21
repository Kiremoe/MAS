using MAS2.GamePieces;

namespace MAS2.Users
{
    public class User
    {

        public int Id { get; set; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _username = value;
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (!value.Equals(null) && value.Length >= 8)
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("Invalid argument: " + nameof(value));
                }
            }
        }

        public GameMaster GameMaster { get; }
        public int GameMasterId { get; }

        public List<Player> PlayerCharacters { get; } = new List<Player>();

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            GameMaster = new GameMaster(this);
            GameMasterId = GameMaster.Id;
        }
    }
}

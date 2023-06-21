using MAS2.Model;

namespace MAS2.Users
{
    public class GameMaster
    {
        public int Id;

        private User _user;
        public User User 
        {
            get => _user;
            set 
            {
                if (value.Equals(null)) { throw new ArgumentNullException(nameof(value)); }
                else { _user = value; }
            }
        }

        private Campain? _camapin;
        public Campain? Campain 
        { 
            get => _camapin;
            set { if(value.Equals(null)) { throw new ArgumentNullException(nameof(value)); } _camapin = value;}
        }

        public GameMaster(User user)
        {
            User = user;
        }

        private GameMaster() { }


    }
}

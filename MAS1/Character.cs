using System.Collections.ObjectModel;

namespace MAS2
{
    public class Character : IGamePiece
    {
        public static List<Character> Characters { get; set; } = new List<Character>();

        private int _id;

        public int Id
        {
            get { return _id; }
        }

        private DateTime _creationDate;

        public DateTime CreationDate
        {
            get { return _creationDate; }
        }

        public string Name { get; set; }

        private int _experiencePoints;

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { if (value < 0) value = 0; _experiencePoints = value; }
        }

        public Equipment Equipment { get; }

        public int Level => 1 + (int)Math.Pow(_experiencePoints, 1.0 / 10);

        private List<CharacterQuest> _charactersQuests { get; } // Asocjacja z atrybutem "CharacterQuest.QuestStatus" *-*

        public ReadOnlyCollection<CharacterQuest> CharacterQuests => _charactersQuests.AsReadOnly();

        public CharacterQuest? FindCharactersQuests(Quest quest)
        {
            foreach (CharacterQuest characterQuest in _charactersQuests)
            {
                if (characterQuest.Quest.Equals(quest))
                {
                    return characterQuest;
                }
            }
            return null;
        }

        public void AddQuest(Quest quest)
        {
            if(quest == null) { throw new ArgumentNullException(nameof(quest)); }
            if(FindCharactersQuests(quest) != null) 
            {
                Console.WriteLine("Character is already on this quest");
                //throw new Exception("Character is already on this quest");
            }
            _charactersQuests.Add(new CharacterQuest(this, quest, CharacterQuest.QuestStatus.Claimed));
        }

        public void AddCharacterQuest(CharacterQuest characterQuest)
        {
            if (characterQuest == null) { throw new ArgumentNullException(nameof(characterQuest)); }
            if (CharacterQuests.Contains(characterQuest)) { throw new Exception("Character has already this characterQuest"); }
        }

        public void CompleteQuest(Quest quest)
        {
            CharacterQuest? characterQuest = FindCharactersQuests(quest);
            if(characterQuest == null)
            {
                Console.WriteLine("Character is not on this quest");
            }
            else if (characterQuest.Status.Equals(CharacterQuest.QuestStatus.Claimed))
            {
                characterQuest.Status = CharacterQuest.QuestStatus.ReadyToReturn;
                Console.WriteLine("Character can now retun the quest");
            }
            else
            {
                Console.WriteLine("Character has already completed the quest's goal");
            }
        }

        public void ReturnQuest(Quest quest)
        {
            CharacterQuest? characterQuest = FindCharactersQuests(quest);
            if (characterQuest == null)
            {
                Console.WriteLine("Character is not on this quest");
            }
            else if (characterQuest.Status.Equals(CharacterQuest.QuestStatus.ReadyToReturn))
            {
                characterQuest.Status = CharacterQuest.QuestStatus.Done;
                Console.WriteLine("Character returned the quest");
            }
            else
            {
                Console.WriteLine("Character can not return the quest yet");
            }
        }

        private Zone _zone;
        public Zone Zone 
        {
            get => _zone;
            set
            {
                if(value == null) { throw new ArgumentNullException(nameof(value)); }
                _zone.Characters.Remove(this);
                _zone = value;
                _zone.Characters.Add(this);
            }
        }

        public Character(string name, Zone zone)
        {
            int maxid = 0;
            foreach (Character character in Characters)
            {
                if (character.Id > maxid) { maxid = character.Id; }
            }
            _id = maxid+1;
            _creationDate = DateTime.UtcNow;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _experiencePoints = 0;
            Equipment = new Equipment(this);
            _charactersQuests = new List<CharacterQuest>();
            _zone = zone ?? throw new ArgumentNullException(nameof(zone));
            Characters.Add(this);
        }
    }
}

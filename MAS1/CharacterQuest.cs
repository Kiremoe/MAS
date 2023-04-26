namespace MAS2
{
    public class CharacterQuest
    {
        public static List<CharacterQuest> CharactersQuests { get; set; } = new List<CharacterQuest>();

        private Character _character;
        public Character Character
        {
            get => _character;
        }
        private Quest _quest;
        public Quest Quest
        {
            get => _quest;
        }

        public QuestStatus Status { get; set; }

        public enum QuestStatus
        {
            Claimed,
            ReadyToReturn,
            Done
        }

        public CharacterQuest(Character character, Quest quest, QuestStatus status)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _quest = quest ?? throw new ArgumentNullException(nameof(_quest));
            if (_character.FindCharactersQuests(_quest) == null) { _character.AddCharacterQuest(this); }
            if (_quest.FindCharactersQuests(_character) == null) { _quest.AddCharacterQuest(this); }
            Status = status;
            CharactersQuests.Add(this);
        }
    }
}

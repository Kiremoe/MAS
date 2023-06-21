using System.ComponentModel.DataAnnotations;

namespace MAS2.GamePieces
{
    public class CharacterQuest
    {
        public int Id;

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

        public CharacterQuest(Character character, Quest quest, QuestStatus status) : this(status)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _quest = quest ?? throw new ArgumentNullException(nameof(_quest));
            if (_character.FindCharactersQuests(_quest) == null) { _character.AddCharacterQuest(this); }
            if (_quest.FindCharactersQuests(_character) == null) { _quest.AddCharacterQuest(this); }
        }

        private CharacterQuest(QuestStatus status)
        {
            Status = status;
        }
    }
}

﻿using System.Collections.ObjectModel;

namespace MAS2.GamePieces
{
    public class Quest : GamePiece
    {
        public string Name { get; set; }
        public string? Goal { get; set; }
        public string? Description { get; set; }
        public int RewardValue { get; set; }

        private List<Item> _rewardItems;
        public IReadOnlyCollection<Item> RewardItems => _rewardItems.AsReadOnly();
        public void AddItemToRewardItems(Item item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            _rewardItems.Add(item);
            if (item.Quest != this) { item.Quest = this; }
        }
        public void RemoveItemFromRewardItems(Item item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            if (!_rewardItems.Contains(item)) { throw new Exception("Reward items does not contain this specific item"); }
            _rewardItems.Remove(item);
            item.Quest = null;
        }

        private List<CharacterQuest> _charactersQuests;
        public IReadOnlyCollection<CharacterQuest> CharactersQuests => _charactersQuests.AsReadOnly();

        public CharacterQuest? FindCharactersQuests(Character character)
        {
            foreach (CharacterQuest characterQuest in _charactersQuests)
            {
                if (characterQuest.Character.Equals(character))
                {
                    return characterQuest;
                }
            }
            return null;
        }

        public void AddCharacterToQuest(Character character)
        {
            if (character == null) { throw new ArgumentNullException(nameof(character)); }
            if (FindCharactersQuests(character) != null) { throw new Exception("Quest already has this character doing it"); }
            _charactersQuests.Add(new CharacterQuest(character, this, CharacterQuest.QuestStatus.Claimed));
        }

        public void AddCharacterQuest(CharacterQuest characterQuest)
        {

            if (characterQuest == null) { throw new ArgumentNullException(nameof(characterQuest)); }
            if (_charactersQuests.Contains(characterQuest)) { throw new Exception("Quest already contains this characterQuest instance"); }
            _charactersQuests.Add(characterQuest);
        }

        public Quest(string name, string? goal, string? description, int rewardValue, List<Item>? rewardItems, List<CharacterQuest>? characterQuests)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Goal = goal;
            Description = description;
            _charactersQuests = new List<CharacterQuest>();
            if (characterQuests != null) { _charactersQuests.AddRange(characterQuests); }
            RewardValue = rewardValue;
            if (rewardItems != null)
            {
                _rewardItems = rewardItems;
            }
            else
            {
                _rewardItems = new List<Item>();
            }
        }

        public Quest(string name) : this(name, null, null, 0, null, new List<CharacterQuest>()) { }
    }
}

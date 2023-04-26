namespace MAS2
{
    public class Item : IGamePiece
    {
        public static List<Item> Items { get; set; } = new List<Item>();

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

        public string Name { get; }
        public float Weight { get; }
        public string? Description { get; }

        public int Value { get; }

        private Quest? _quest;
        public Quest? Quest 
        {
            get => _quest;
            set 
            {
                if (Equipment != null && value != null) { throw new Exception("Cannot add item to Quest. It is already in use"); }
                if (value == null && _quest != null) { _quest.RemoveItemFromRewardItems(this); }
                _quest = value;
                if (_quest != null && !_quest.RewardItems.Contains(this)) { _quest.AddItemToRewardItems(this); }
                
            }
        }

        private Equipment? _equipment;
        public Equipment? Equipment 
        {
            get => _equipment;
            set
            {
                if (Quest != null && value != null ) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _equipment != null) { _equipment.RemoveItemFromEquipment(this); }
                _equipment = value;
                if (_equipment != null && !_equipment.IfEquipmentHasItem(this)) { _equipment.AddItemToBags(this); }
            }
        }

        public EquipmentType Type { get; }

        public enum EquipmentType
        {
            Helm,
            Chest,
            Gloves,
            Boots,
            Weapon,
            Consumable,
            Other
        }

        public bool IfItemIsInUse()
        {
            if (Quest != null) { return true; }
            if (Equipment != null) { return true; }
            return false;
        }

        public Item(string name, float weight, string? description, int value, EquipmentType type)
        {
            int maxid = 0;
            foreach (Item item in Items)
            {
                if (item.Id > maxid) { maxid = item.Id; }
            }
            _id = maxid+1;
            Name = name;
            Weight = weight;
            Description = description;
            _creationDate = DateTime.UtcNow;
            Value = value;
            Type = type;
            Items.Add(this);
        }
    }
}
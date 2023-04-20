namespace MAS1
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

        public Equipment? Equipment { get; set; }
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

        public Item(string name, float weight, string? description, int value, Equipment? equipment, EquipmentType type)
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
            Equipment = equipment;
            Type = type;
            Items.Add(this);
        }
    }
}
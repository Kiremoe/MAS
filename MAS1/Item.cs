namespace MAS1
{
    public class Item : IGamePiece
    {
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

        public static List<Item> Items { get; set; } = new List<Item>();

        public string Name { get; set; }
        public float Weight { get; set; }
        public string? Description { get; set; }

        public int Value { get; set; }

        public Equipment? Equipment { get; set; }
        public EquipmentType Type { get; set; }

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
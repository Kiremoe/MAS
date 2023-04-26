namespace MAS2
{
    public class Equipment
    {
        public static List<Equipment> Equipments { get; set; } = new List<Equipment>();

        public int Value => GetValue();

        private int GetValue()
        {
            int sum = 0;
            if (Helm != null)
            {
                sum += Helm.Value;
            }
            if (Chest != null)
            {
                sum += Chest.Value;
            }
            if (Gloves != null)
            {
                sum += Gloves.Value;
            }
            if (Boots != null)
            {
                sum += Boots.Value;
            }
            if (Weapon != null)
            {
                sum += Weapon.Value;
            }
            foreach(Item item in GetItemsInBags())
            {
                sum += item.Value;
            }
            return sum;
        }

        private Item? _helm;
        public Item? Helm 
        {
            get => _helm;
            set
            {
                if(value != null && !value.Type.Equals(Item.EquipmentType.Helm)) 
                { 
                    throw new InvalidDataException(String.Format("Trying to put not {0} in {1} slot", value.Name, Item.EquipmentType.Helm.ToString())); 
                }
                _helm = value;
                if(_helm != null) { _helm.Equipment = this; }
            }
        }

        private Item? _chest;
        public Item? Chest 
        {
            get => _chest;
            set
            {
                if (value != null && !value.Type.Equals(Item.EquipmentType.Chest))
                {
                    throw new InvalidDataException(String.Format("Trying to put not {0} in {1} slot", value.Name, Item.EquipmentType.Chest.ToString()));
                }
                _chest = value;
                if(_chest != null) { _chest.Equipment = this; }
            }
        }

        private Item? _gloves;
        public Item? Gloves 
        {
            get => _gloves;
            set
            {
                if (value != null && !value.Type.Equals(Item.EquipmentType.Gloves))
                {
                    throw new InvalidDataException(String.Format("Trying to put not {0} in {1} slot", value.Name, Item.EquipmentType.Gloves.ToString()));
                }
                _gloves = value;
                if(_gloves != null) { _gloves.Equipment = this; }
            }
        }

        private Item? _boots;
        public Item? Boots 
        {
            get => _boots;
            set
            {
                if (value != null && !value.Type.Equals(Item.EquipmentType.Boots))
                {
                    throw new InvalidDataException(String.Format("Trying to put not {0} in {1} slot", value.Name, Item.EquipmentType.Boots.ToString()));
                }
                _boots = value;
                if(_boots != null) { _boots.Equipment = this; }
            }
        }

        private Item? _weapon;
        public Item? Weapon 
        {
            get => _weapon;
            set
            {
                if (value != null && !value.Type.Equals(Item.EquipmentType.Weapon))
                {
                    throw new InvalidDataException(String.Format("Trying to put {0} in {1} slot", value.Name, Item.EquipmentType.Weapon.ToString()));
                }
                _weapon = value;
                if(_weapon != null) { _weapon.Equipment = this; }
            }
        }

        public Character Character { get; }

        private class Bag
        {
            private Equipment _equipment { get; }

            private int _capacity;
            public int Capacity
            {
                get => _capacity;
            }
            private List<Item> _items { get; }

            public List<Item> GetItems()
            {
                return _items;
            }

            public void AddItem(Item item)
            {
                if(_items.Count < _capacity)
                {
                    _items.Add(item);
                    item.Equipment = _equipment;
                }
                else
                {
                    Console.WriteLine("Can not add item. Bag is already full");
                }
            }

            public int GetNumOfItems()
            {
                return _items.Count;
            }

            public void RemoveItemFromBag(Item item)
            {
                if(item == null) { throw new ArgumentNullException(nameof(item)); }
                if (!this.GetItems().Contains(item)) { throw new Exception("Bag does not contain this item"); }
                _items.Remove(item);
                item.Equipment = null;
            }

            public Bag(int capacity, Equipment equipment)
            {
                if(capacity <= 0)
                {
                    throw new ArgumentException("Bag capacity can not be less then 1");
                }
                _capacity = capacity;
                _items = new List<Item>();
                _equipment = equipment;
            }
        }

        private List<Bag> _bags;

        public void AddNewBag(int capacity)
        {
            _bags.Add(new Bag(capacity, this));
        }

        public void AddItemToBags(Item item)
        {
            foreach(Bag bag in _bags)
            {
                if(bag.Capacity > bag.GetNumOfItems())
                {
                    bag.AddItem(item);
                    return;
                }
            }
            Console.WriteLine("There is no space in the bags");
        }

        public List<Item> GetItemsInBags()
        {
            List<Item> result = new List<Item>();
            foreach (Bag bag in _bags)
            {
                result.AddRange(bag.GetItems());
            }
            return result;
        } 

        public bool IfEquipmentHasItem(Item item)
        {
            if(item == Helm) { return true; }
            else if (item == Chest) { return true; }
            else if (item == Gloves) { return true; }
            else if (item == Boots) { return true; }
            else if (item == Weapon) { return true; }
            foreach(Bag bag in _bags)
            {
                foreach(Item itemInBag in bag.GetItems())
                {
                    if (item == itemInBag) { return true; }
                }
            }
            return false;
        }

        public void RemoveItemFromEquipment(Item item)
        {
            if (item == Helm) 
            { 
                item.Equipment = null;
                Helm = null;
                return; 
            }
            else if (item == Chest) 
            {
                item.Equipment = null;
                Chest = null;
                return;
            }
            else if (item == Gloves) 
            {
                item.Equipment = null;
                Gloves = null;
                return; 
            }
            else if (item == Boots) 
            {
                item.Equipment = null;
                Boots = null;
                return; 
            }
            else if (item == Weapon) 
            {
                item.Equipment = null;
                Weapon = null;
                return;
            }
            foreach (Bag bag in _bags)
            {
                if (bag.GetItems().Contains(item))
                {
                    bag.RemoveItemFromBag(item);
                    return;
                }
            }
            throw new Exception("Equipment does not contain specified item");
        }


        public Equipment(Item? helm, Item? chest, Item? gloves, Item? boots, Item? weapon, Character character, List<int> capacitiesOfBags, List<Item>? itemsInBags)
        {
            if(capacitiesOfBags == null) { throw new ArgumentNullException(nameof(capacitiesOfBags)); }
            if(itemsInBags != null && itemsInBags.Count > capacitiesOfBags.Sum()) { throw new Exception("List of itmes exceeds the nuber of avaiable slots in bags"); }
            Character = character ?? throw new ArgumentNullException(nameof(character));
            Helm = helm;
            Chest = chest;
            Gloves = gloves;
            Boots = boots;
            Weapon = weapon;
            _bags = new List<Bag>();
            foreach (int capacity in capacitiesOfBags)
            {
                AddNewBag(capacity);
            }
            if(itemsInBags != null)
            {
                foreach (Item item in itemsInBags)
                {
                    AddItemToBags(item);
                }
            }
            Equipments.Add(this);
        }

        public Equipment(Character character) : this(null, null, null, null, null, character, new List<int> { 10 }, null) { }
    }
}

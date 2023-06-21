using System.Xml.Linq;

namespace MAS2.GamePieces
{
    public class Item : GamePiece
    {
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

        public int? QuestId;

        private Equipment? _equipment;
        public Equipment? Equipment
        {
            get => _equipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && IfItemIsInUse()) { RemoveFromEq(); }
                _equipment = value;
                if (value == null)
                {
                    EquipmentId = null;

                }
                else
                {
                    EquipmentId = value.Id;
                }

                if (_equipment != null && !_equipment.IfEquipmentHasItem(this)) { _equipment.AddItemToBags(this); }
            }
        }

        public int? EquipmentId;

        private Equipment? _helmEquipment;
        public Equipment? HelmEquipment
        {
            get => _helmEquipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _helmEquipment != null) { _helmEquipment.RemoveItemFromEquipment(this); }
                _helmEquipment = value;
                if (value == null)
                {
                    _helmEquipment = null;

                }
                else
                {
                    HelmEquipmentId = value.Id;
                }

                if (_helmEquipment != null && !_helmEquipment.IfEquipmentHasItem(this)) { _helmEquipment.AddItemToBags(this); }
            }
        }

        public int? HelmEquipmentId;

        private Equipment? _chestEquipment;
        public Equipment? ChestEquipment
        {
            get => _chestEquipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _chestEquipment != null) { _chestEquipment.RemoveItemFromEquipment(this); }
                _chestEquipment = value;
                if (value == null)
                {
                    ChestEquipmentId = null;

                }
                else
                {
                    ChestEquipmentId = value.Id;
                }

                if (_chestEquipment != null && !_chestEquipment.IfEquipmentHasItem(this)) { _chestEquipment.AddItemToBags(this); }
            }
        }

        public int? ChestEquipmentId;

        private Equipment? _glovesEquipment;
        public Equipment? GlovesEquipment
        {
            get => _glovesEquipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _glovesEquipment != null) { _glovesEquipment.RemoveItemFromEquipment(this); }
                _glovesEquipment = value;
                if (value == null)
                {
                    GlovesEquipmentId = null;

                }
                else
                {
                    GlovesEquipmentId = value.Id;
                }

                if (_glovesEquipment != null && !_glovesEquipment.IfEquipmentHasItem(this)) { _glovesEquipment.AddItemToBags(this); }
            }
        }

        public int? GlovesEquipmentId;

        private Equipment? _bootsEquipment;
        public Equipment? BootsEquipment
        {
            get => _bootsEquipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _bootsEquipment != null) { _bootsEquipment.RemoveItemFromEquipment(this); }
                _bootsEquipment = value;
                if (value == null)
                {
                    BootsEquipmentId = null;

                }
                else
                {
                    BootsEquipmentId = value.Id;
                }

                if (_bootsEquipment != null && !_bootsEquipment.IfEquipmentHasItem(this)) { _bootsEquipment.AddItemToBags(this); }
            }
        }

        public int? BootsEquipmentId;

        private Equipment? _weaponEquipment;
        public Equipment? WeaponEquipment
        {
            get => _weaponEquipment;
            set
            {
                if (Quest != null && value != null) { throw new Exception("Cannot add item to Equipment. It is already in use"); }
                if (value == null && _weaponEquipment != null) { _weaponEquipment.RemoveItemFromEquipment(this); }
                _weaponEquipment = value;
                if (value == null)
                {
                    WeaponEquipmentId = null;

                }
                else
                {
                    WeaponEquipmentId = value.Id;
                }

                if (_weaponEquipment != null && !_weaponEquipment.IfEquipmentHasItem(this)) { _weaponEquipment.AddItemToBags(this); }
            }
        }
        public int? WeaponEquipmentId;


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
            if (
                Quest != null ||
                Equipment != null ||
                HelmEquipment != null ||
                ChestEquipment != null ||
                GlovesEquipment != null ||
                BootsEquipment != null ||
                WeaponEquipment != null
                )
            { return true; }
            return false;
        }

        public void RemoveFromEq()
        {
            if( Equipment != null) 
            {
                Equipment.RemoveItemFromEquipment(this);
                Equipment = null; return; 
            }
            if (HelmEquipment != null) 
            {
                HelmEquipment.RemoveItemFromEquipment(this);
                HelmEquipment = null; return; 
            }
            if (ChestEquipment != null) 
            {
                ChestEquipment.RemoveItemFromEquipment(this);
                ChestEquipment = null; return; 
            }
            if (GlovesEquipment != null) 
            {
                GlovesEquipment.RemoveItemFromEquipment(this);
                GlovesEquipment = null; return; 
            }
            if (BootsEquipment != null) 
            {
                BootsEquipment.RemoveItemFromEquipment(this);
                BootsEquipment = null; return; 
            }
            if (WeaponEquipment != null) 
            {
                WeaponEquipment.RemoveItemFromEquipment(this);
                WeaponEquipment = null; return; 
            }
        }

        public Item(string name, float weight, string? description, int value, EquipmentType type):this()
        {
            Name = name;
            Weight = weight;
            Description = description;
            Value = value;
            Type = type;
        }

        private Item(){}
    }
}
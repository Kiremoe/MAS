using System.Collections.ObjectModel;

namespace MAS2.GamePieces
{
    public class Enemy : GamePiece
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int _maxHealth;
        public int MaxHealth 
        { 
            get => _maxHealth;
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Argument should not be negative: " + nameof(value)); }
                else { _maxHealth = value; }
            }
        }

        public Character.AttackType AttackType { get; set; }

        private float _attackRange;
        public float AttackRange 
        {
            get => _attackRange;
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("Value should not be negative or equal zero"); }
                else{_attackRange = value;}
            }
        }

        private int _damage;
        public int Damage 
        {
            get => _damage;
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Value should not be negative"); }
                else { _damage = value; }
            }
        }

        private List<EnemiesZones> _ez = new List<EnemiesZones>();
        public IReadOnlyCollection<EnemiesZones> EnemiesZones => _ez.AsReadOnly();
        public void AddEnemyInstanceToZone(EnemiesZones ez) { if (!EnemiesZones.Contains(ez)) { _ez.Add(ez); } }
        public void RemoveEnemyInstanceFromZone(EnemiesZones ez) { if (EnemiesZones.Contains(ez)) { _ez.Remove(ez); } }

        public Enemy(string name, int maxHealth, Character.AttackType attackType, float attackRange, int damage)
        {
            Name = name;
            MaxHealth = maxHealth;
            AttackType = attackType;
            AttackRange = attackRange;
            Damage = damage;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}

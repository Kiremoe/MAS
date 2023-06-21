namespace MAS2.GamePieces
{
    public class EnemiesZones
    {
        public int Id { get; }
        public int Health { get; set; }
        public bool IsAlife => Health > 0;

        private Enemy _enemy;
        public Enemy Enemy 
        {
            get => _enemy; 
        }

        private Zone _zone;
        public Zone Zone
        {
            get => _zone;
        }


        public EnemiesZones(Enemy enemy, Zone zone) : this()
        {
            if (enemy.Equals(null) || zone.Equals(null)) { throw new ArgumentNullException("EnemiesZones constructor does not take nulls"); }
            _enemy = enemy;
            _zone = zone;
            enemy.AddEnemyInstanceToZone(this);
            zone.AddEnemyInstanceToZone(this);
            Health = enemy.MaxHealth;
        }

        private EnemiesZones()
        {
            
        }
    }
}

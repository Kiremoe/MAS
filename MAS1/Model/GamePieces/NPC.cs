namespace MAS2.GamePieces
{
    public class NPC : Character
    {
        public List<string> ListOfDialog { get; } = new List<string>();
        public bool IsFriendly { get; set; }

        public NPC(List<string> dialogs, bool isFriendly,string name, Zone zone) : base(name, zone)
        {
            if (!dialogs.Equals(null)) { ListOfDialog.AddRange(dialogs); }
            IsFriendly = isFriendly;
        }

        private NPC(): base("",new Zone("","")) { }

        public override string? ToString()
        {
            return Name;
        }
    }
}

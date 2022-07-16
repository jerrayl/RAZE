namespace RAZE.Entities
{
    public class PlayerTroop : BaseEntity
    {
        public int TroopId { get; set; }

        public int PlayerId { get; set; }

        public int BoardX { get; set; }

        public int BoardY { get; set; }

        public int BoardSlot { get; set; }

        public int Health { get; set; }

        public virtual Troop Troop { get; set; }

        public virtual PlayerSession Player { get; set; }
    }
}

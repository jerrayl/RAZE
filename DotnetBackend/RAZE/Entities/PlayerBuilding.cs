namespace RAZE.Entities
{
    public class PlayerBuilding : BaseEntity
    {
        public int BuildingId { get; set; }

        public int PlayerId { get; set; }

        public int BoardX { get; set; }

        public int BoardY { get; set; }

        public int Health { get; set; }

        public virtual Building Building { get; set; }

        public virtual PlayerSession Player { get; set; }
    }
}

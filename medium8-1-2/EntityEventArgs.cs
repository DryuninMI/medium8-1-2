using System;

namespace medium8_1_2
{
    public class EntityEventArgs : EventArgs
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public string Name { get; private set; }

        public EntityEventArgs(Entity entity)
        {
            CoordX = entity.CoordX;
            CoordY = entity.CoordY;
            Name = entity.Name;
        }
    }
}
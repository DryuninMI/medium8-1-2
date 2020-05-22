using System;
using System.Collections.Generic;
using System.Linq;

namespace medium8_1_2
{
    public class Entity
    {
        private int _coordX;
        private int _coordY;

        public int CoordX
        {
            get { return _coordX; }
            private set
            {
                if (value < 0)
                {
                    _coordX = 0;
                }
                else
                {
                    _coordX = value;
                }
            }
        }
        public int CoordY
        {
            get { return _coordY; }
            private set
            {
                if (value < 0)
                {
                    _coordY = 0;
                }
                else
                {
                    _coordY = value;
                }
            }
        }

        public string Name { get; private set; }
        public bool IsAlive { get; set; }

        public Entity(string name, int coordX, int coordY)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Entity name must not be empty!");
            }

            if (coordX <= 0 || coordY <= 0)
            {
                throw new Exception("In Initial entity coord must not be zero or negative number!");
            }

            CoordX = coordX;
            CoordY = coordY;

            Name = name;
            IsAlive = true;
        }

        public void AddRandomNumber(Random random, int minValue, int maxValue)
        {
            CoordX += random.Next(minValue, maxValue);
            CoordY += random.Next(minValue, maxValue);
        }
        public void KillEqualsEntities(IEnumerable<Entity> entities)
        {
            var equalsEntities = entities.Where(x => x.CoordX == CoordX && x.CoordY == CoordY);

            if (equalsEntities.Count() > 0)
            {
                IsAlive = false;
                foreach (var entity in equalsEntities)
                {
                    entity.IsAlive = false;
                }
            }
        }
    }
}
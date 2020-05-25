using System;
using System.Collections.Generic;
using System.Linq;

namespace medium8_1_2
{
    public class Entity
    {
        public uint CoordX { get; private set; }
        public uint CoordY { get; private set; }
        public string Name { get; private set; }

        public Entity(string name, uint coordX, uint coordY)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }         

            CoordX = coordX;
            CoordY = coordY;
            Name = name;
        }

        public void Offset(Random random, int minValue, int maxValue)
        {
            CoordX = CheckedOverflow(random.Next(minValue, maxValue), CoordX);
            CoordY = CheckedOverflow(random.Next(minValue, maxValue), CoordY);
        }

        private uint CheckedOverflow(int number, uint coord)
        {
            uint resultCoord = coord;

            try
            {
                checked
                {
                    resultCoord = (uint)(resultCoord + number);
                }
            }
            catch (OverflowException)
            {
                resultCoord = 0U;
            }

            return resultCoord;
        }
    }
}
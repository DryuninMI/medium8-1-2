using System;
using System.Collections.Generic;
using System.Linq;

namespace medium8_1_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity>
            {
                new Entity("1", 5, 5),
                new Entity("2", 10, 10),
                new Entity("3", 15, 15)
            };

            int maxCoordY = (int)entities.Max(entity => entity.CoordY);

            Field field = new Field(entities);
            field.EntityAlived += OnEntityAlived;
            field.Simulate();

            Console.SetCursorPosition(0, maxCoordY + 1);
        }

        private static void OnEntityAlived(Entity obj)
        {
            Console.SetCursorPosition((int)obj.CoordX, (int)obj.CoordY);
            Console.Write(obj.Name);
        }
    }
}
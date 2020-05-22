using System;
using System.Collections.Generic;

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
                new Entity("3", 15, 15),
            };

            SimulateField field = new SimulateField(entities);
            field.OnAliveEntity += SimulateField_OnAliveEntity;
            field.Simulate();

            Console.SetCursorPosition(0, field.MaxCoordYInEntities + 1);
            Console.ReadKey();
        }

        private static void SimulateField_OnAliveEntity(object sender, EntityEventArgs e)
        {
            Console.SetCursorPosition(e.CoordX, e.CoordY);
            Console.Write(e.Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace medium8_1_2
{
    public class SimulateField
    {
        private readonly List<Entity> _entities;
        public event EventHandler<EntityEventArgs> OnAliveEntity;
        public int MaxCoordYInEntities { get; private set; }

        public SimulateField(List<Entity> entities)
        {
            if (entities.Count < 3)
            {
                throw new Exception("In Initial entities count must not be less than three");
            }

            _entities = entities;
        }

        public void Simulate()
        {
            Random random = new Random();

            while (_entities.All(x => x.IsAlive))
            {
                KillEqualsEntities(_entities);
                _entities.ForEach(x => x.AddRandomNumber(random, -1, 1));
                GetMaxCoordYInEntities(_entities);
                AliveEntityView(_entities);
            }
        }
        private void KillEqualsEntities(List<Entity> entities)
        {
            int SkipElements = 1;

            entities.ForEach(x =>
            {
                x.KillEqualsEntities(entities.Skip(SkipElements));
                SkipElements++;
            });
        }
        private void AliveEntityView(List<Entity> entities)
        {
            entities.ForEach(x =>
            {
                if (x.IsAlive)
                    OnAliveEntity?.Invoke(this, new EntityEventArgs(x));
            });
        }
        private void GetMaxCoordYInEntities(List<Entity> entities)
        {
            int maxCoordYInCurrentEntities = entities.Max(x => x.CoordY);
            if (maxCoordYInCurrentEntities > MaxCoordYInEntities)
            {
                MaxCoordYInEntities = maxCoordYInCurrentEntities;
            }
        }
    }
}

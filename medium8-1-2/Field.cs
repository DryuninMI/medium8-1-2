using System;
using System.Collections.Generic;
using System.Linq;

namespace medium8_1_2
{
    public class Field
    {
        private readonly List<Entity> _entities;
        public event Action<Entity> EntityAlived;

        public Field(List<Entity> entities)
        {
            if (entities.Count < 3)
            {
                throw new ArgumentOutOfRangeException();
            }

            _entities = entities;
        }

        public void Simulate()
        {
            Random random = new Random();
            List<Entity> activeEntity = _entities.ToList();

            while (activeEntity.Count > 0)
            {
                activeEntity = KillEqualsEntities(activeEntity);
                _entities.ForEach(x => x.Offset(random, -1, 1));
                AliveEntityView(activeEntity);
            }
        }

        private List<Entity> KillEqualsEntities(List<Entity> activEntities)
        {
            int skipElements = 1;

            _entities.ForEach(entity =>
            {
                var equalsEntities = _entities.Skip(skipElements).Where(entityAfterSkip => entityAfterSkip.CoordX == entity.CoordX && entityAfterSkip.CoordY == entity.CoordY);

                if (equalsEntities.Count() > 0)
                {
                    activEntities.Remove(entity);

                    foreach (var equalEntity in equalsEntities)
                    {
                        activEntities.Remove(equalEntity);
                    }
                }

                skipElements++;
            });

            return activEntities;
        }

        private void AliveEntityView(List<Entity> activEntities)
        {
            activEntities.ForEach(entity =>
            {
                EntityAlived?.Invoke(entity);
            });
        }
    }
}

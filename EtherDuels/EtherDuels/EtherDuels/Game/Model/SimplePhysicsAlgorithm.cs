using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    class SimplePhysicsAlgorithm : Physics
    {
        private CollisionHandler collisionHandler;
        private World world;

        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
        }

        public override void Update(GameTime gameTime)
        {
            WorldObject[] objects = world.GetWorldObjects();

            foreach (WorldObject worldObject in objects)
            {
            }
        }

        private void CheckCollision(WorldObject object1, WorldObject object2)
        {

        }

    }
}

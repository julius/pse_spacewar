using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; // wie kann man das reduzieren auf WorldObject?

namespace EtherDuels.Game.View
{
    public class WorldObjectView
    {
        WorldObject worldObject;
        Microsoft.Xna.Framework.Graphics.Model model;

        public WorldObjectView(Microsoft.Xna.Framework.Graphics.Model model, WorldObject worldObject)
        {
            this.model = model;
            this.worldObject = worldObject;
        }

        public void Draw(Viewport viewport, Vector3 cameraPosition)
        {
            Vector3 modelPosition = new Vector3(worldObject.Position.X, 0, worldObject.Position.Y);
            float modelRotation = 0f; // gameTime.TotalGameTime.Milliseconds * 0.01f;

            Matrix matrixWorld = Matrix.CreateRotationY(modelRotation) * Matrix.CreateTranslation(modelPosition);
            Matrix matrixView = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix matrixProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), viewport.AspectRatio, 1.0f, 10000.0f);

            this.model.Draw(matrixWorld, matrixView, matrixProjection);
        }
    }
}

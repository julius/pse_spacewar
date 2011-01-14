using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; // TODO wie kann man das reduzieren auf WorldObject?

namespace EtherDuels.Game.View
{   
    /// <summary>
    /// Defines the view of a WorldObject.
    /// </summary>
    public class WorldObjectView
    {
        WorldObject worldObject;

        public WorldObject WorldObject
        {
            get { return worldObject; }
        }
        Microsoft.Xna.Framework.Graphics.Model model;
        /// <summary>
        /// Creates a new WorldObjectView object.
        /// </summary>
        /// <param name="model">The dedicated graphic model for drawing the WorldObject.</param>
        /// <param name="worldObject">The dedicated WorldObject to check it for changes.</param>
        public WorldObjectView(Microsoft.Xna.Framework.Graphics.Model model, WorldObject worldObject)
        {
            this.model = model;
            this.worldObject = worldObject;
        }

        /// <summary>
        /// Draws the WorldObjectView using the attributive model.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="cameraPosition">The position of which the camera looks on the WorldObject. .</param>
        public void Draw(Viewport viewport, Vector3 cameraPosition)
        {
            Vector3 modelPosition = new Vector3(worldObject.Position.X, 0, worldObject.Position.Y);
           // float modelRotation = 0f; // gameTime.TotalGameTime.Milliseconds * 0.01f;

            Matrix matrixWorld = Matrix.CreateRotationY(-worldObject.Rotation) * Matrix.CreateTranslation(modelPosition);
            Matrix matrixView = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix matrixProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), viewport.AspectRatio, 1.0f, 10000.0f);

            this.model.Draw(matrixWorld, matrixView, matrixProjection);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model; //TODO Zugriff genauer einschränken???????????
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.View
{   
    /// <summary>
    /// Defines the view of a WorldObject.
    /// </summary>
    public class WorldObjectView
    {
        WorldObject worldObject;
        Microsoft.Xna.Framework.Graphics.Model model;
        private float angle = 0;

        public WorldObject WorldObject
        {
            get { return worldObject; }
        }
        
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
        /// Draws the WorldObjectView using the according model.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="cameraPosition">The position of which the camera looks on the WorldObject. .</param>
        /// <param name="gameTime">The frame's time object.</param>
        public void Draw(Viewport viewport, Vector3 cameraPosition, GameTime gameTime)
        {
            Vector3 modelPosition = new Vector3(worldObject.Position.X, 0, worldObject.Position.Y);
           // float modelRotation = 0f; // gameTime.TotalGameTime.Milliseconds * 0.01f;

            Matrix matrixWorld = Matrix.CreateRotationY(-worldObject.Rotation) * Matrix.CreateTranslation(modelPosition);
            Matrix matrixView = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix matrixProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), viewport.AspectRatio, 1.0f, 10000.0f);

            if (this.worldObject is Explosion)
            {
                float scale = (float)(gameTime.TotalGameTime.TotalMilliseconds - ((Explosion)this.worldObject).CreationTime.TotalMilliseconds);
                matrixWorld = Matrix.CreateScale(scale * scale * 0.001f) * matrixWorld;
            }

            if (this.worldObject is Planet)
            {
                angle += 0.0003f;
                matrixWorld = Matrix.CreateRotationZ(3 * angle) * Matrix.CreateRotationX(angle);
            }

            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
                        
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = matrixWorld;
                    effect.View = matrixView;
                    effect.Projection = matrixProjection;
                    effect.PreferPerPixelLighting = true;

                    effect.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                    effect.DiffuseColor = new Vector3(0.8f);
                    effect.AmbientLightColor = new Vector3(0.3f);
                }

                mesh.Draw();
            }

         

            this.model.Draw(matrixWorld, matrixView, matrixProjection);
        }
    }
}

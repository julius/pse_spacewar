using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.View
{   
    /// <summary>
    /// The WorldObjectView draws its assigned world object.
    /// </summary>
    public class WorldObjectView
    {
        private WorldObject worldObject;
        private Microsoft.Xna.Framework.Graphics.Model model;
        private float angle = 0;

        /// <summary>
        /// Returns the assigned world object.
        /// </summary>
        /// <returns>The assigned WorldObject.</returns>
        public WorldObject WorldObject
        {
            get { return worldObject; }
        }
        
        /// <summary>
        /// Creates a new WorldObjectView object.
        /// </summary>
        /// <param name="model">The assigned graphics model for drawing the world object.</param>
        /// <param name="worldObject">The assigned world object.</param>
        public WorldObjectView(Microsoft.Xna.Framework.Graphics.Model model, WorldObject worldObject)
        {
            this.model = model;
            this.worldObject = worldObject;
        }

        public WorldObjectView(WorldObject worldObject)
        {
            this.worldObject = worldObject;
        }

        /// <summary>
        /// Draws the WorldObjectView using the according model.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="cameraPosition">The position which the camera takes when looking at the world object.</param>
        /// <param name="gameTime">The frame's time object.</param>
        public void Draw(Viewport viewport, Vector3 cameraPosition, GameTime gameTime)
        {
            Vector3 modelPosition = new Vector3(worldObject.Position.X, 0, worldObject.Position.Y);
            Matrix matrixWorld = Matrix.CreateScale(1.0f);
            if (this.worldObject is Planet)
            {
                if ((worldObject as Planet).IsFlexible == false)
                {
                    angle += 0.0003f;
                    matrixWorld = Matrix.CreateRotationZ(3 * angle) * Matrix.CreateRotationX(angle) * matrixWorld;
                }
                matrixWorld *= Matrix.CreateScale(this.worldObject.Radius / 100 * 0.4f) * matrixWorld;
            }
            matrixWorld *= Matrix.CreateRotationY(-worldObject.Rotation) * Matrix.CreateTranslation(modelPosition);

            Matrix matrixView = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix matrixProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), viewport.AspectRatio, 1.0f, 10000.0f);
            
            if (this.worldObject is Explosion)
            {
                float scale = (float)(gameTime.TotalGameTime.TotalMilliseconds - ((Explosion)this.worldObject).CreationTime.TotalMilliseconds);
                matrixWorld = Matrix.CreateScale(scale * scale * 0.0004f) * matrixWorld;
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
                    effect.AmbientLightColor = new Vector3(0.7f, 0.5f, 0.7f);
                }

                mesh.Draw();
             }

             this.model.Draw(matrixWorld, matrixView, matrixProjection);

              
            /* Draws the spaceship twice if it leaves the window boundaries.*/
             if (this.worldObject is Spaceship )
             {
                 Vector2 position = worldObject.Position;

                 if (4000 - this.worldObject.Position.X < this.worldObject.Radius) // right boundary 
                 {
                    
                     this.worldObject.Position = new Vector2((-8000 + this.worldObject.Position.X), this.worldObject.Position.Y);

                 }
                 else
                 {
                     if (4000 + this.worldObject.Position.X < this.worldObject.Radius) // left boundary
                     {
                         this.worldObject.Position = new Vector2((8000 + this.worldObject.Position.X), this.worldObject.Position.Y);

                     }

                 }

                 if (2900 - this.worldObject.Position.Y < this.worldObject.Radius) // lower boundary
                 {
                    
                     this.worldObject.Position = new Vector2(this.worldObject.Position.X, (-6200 + this.worldObject.Position.Y));

                 }
                 else
                 {
                     if (3300 + this.worldObject.Position.Y < this.worldObject.Radius) // upper boundary
                     {
                         
                         this.worldObject.Position = new Vector2(this.worldObject.Position.X,(6200 + this.worldObject.Position.Y));
                                
                     }
                 }

                 matrixWorld = Matrix.CreateScale(1.0f) * Matrix.CreateRotationY(-worldObject.Rotation) * Matrix.CreateTranslation(new Vector3(this.worldObject.Position.X, 0, this.worldObject.Position.Y));

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
                         effect.AmbientLightColor = new Vector3(0.7f, 0.5f, 0.7f);
                     }

                     mesh.Draw();
                 }

                 this.model.Draw(matrixWorld, matrixView, matrixProjection);

                 this.worldObject.Position = position;

             }
         
        }
    }
}

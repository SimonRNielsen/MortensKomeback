﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    public class Camera2D
    {
        private Vector2 position = new Vector2();
        private readonly GraphicsDevice _graphicsDevice;

        /// <summary>
        /// Property to access the posi
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Used to set the zoomlevel of the viewport (scaled float)
        /// </summary>
        public float Zoom { get; set; }

        /// <summary>
        /// Used to rotate the camera
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Constructor for the camera viewport
        /// </summary>
        /// <param name="graphicsDevice">Defines which graphicsdevice to get viewport parameters from</param>
        /// <param name="position">Defines starting position of the viewport</param>
        public Camera2D(GraphicsDevice graphicsDevice, Vector2 position)
        {
            _graphicsDevice = graphicsDevice;
            Position = position;
            Zoom = 0.6f;
            Rotation = 0.0f;
        }

        /// <summary>
        /// Transforms the cameraviewport to return value
        /// </summary>
        /// <returns>Center of screen location</returns>
        public Matrix GetTransformation()
        {
            var screenCenter = new Vector3(_graphicsDevice.Viewport.Width / 2f, _graphicsDevice.Viewport.Height / 2f, 0);

            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom, Zoom, 1) *
                   Matrix.CreateTranslation(screenCenter);
        }
    }
}

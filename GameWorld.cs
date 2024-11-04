using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> newGameObjects = new List<GameObject>();
        private static Camera2D camera;

        /// <summary>
        /// Property to get/set the position of the camera, in this case relative to the players position
        /// </summary>
        public static Camera2D Camera { get => camera; set => camera = value; }

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera2D(GraphicsDevice, Vector2.Zero);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: camera.GetTransformation(), samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);

                /*
            foreach (GameObject other in gameObjects)
            {
                if (gameObject is Player && other is Enemy)
                {
                    gameObject.CheckCollision(other);
                    other.CheckCollision(gameObject);
                }
                if (gameObject is Laser && other is Enemy)
                {
                    gameObject.CheckCollision(other);
                    other.CheckCollision(gameObject);
                }
            }
                */

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

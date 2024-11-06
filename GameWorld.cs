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
            gameObjects.Add(new PowerUp(new Vector2(150, 300), 0));
            //gameObjects.Add(new Player());
            gameObjects.Add(new CharacterGenerator());
            gameObjects.Add(new Background(_graphics));
            gameObjects.AddRange(new Environment(_graphics).Surfaces); //Adding the environment to gameObjects
            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera2D(GraphicsDevice, Vector2.Zero);


            foreach (GameObject go in gameObjects)
            {
                go.LoadContent(Content);
            }

            // TODO: use this.Content to load your game content here
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (GameObject other in gameObjects)
                {
                    if (gameObject is Player && other is Enemy)
                    {
                        gameObject.CheckCollision(other);
                        other.CheckCollision(gameObject);
                    }

                    if (gameObject is Player && other is Surface)
                    {
                        gameObject.CheckCollision(other);
                        other.CheckCollision(gameObject);
                    }

                    if (gameObject is Ammo && other is Surface)
                    {
                        gameObject.CheckCollision(other);
                        other.CheckCollision(gameObject);
                    }

                    if (gameObject is PowerUp && other is Player)
                    {
                        gameObject.CheckCollision(other);
                        other.CheckCollision(gameObject);
                    }
                }
                gameObject.Update(gameTime);
            }
            foreach (GameObject newGameObject in newGameObjects)
            {
                newGameObject.LoadContent(Content);
                gameObjects.Add(newGameObject);
            }
            newGameObjects.Clear();

            gameObjects.RemoveAll(gameObject => gameObject.Health < 1);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: Camera.GetTransformation(), samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

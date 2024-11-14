using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MortensKomeback
{
    public class GameWorld : Game
    {
        #region Fields

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> newGameObjects = new List<GameObject>();
        private static Camera2D camera;
        public static bool leftMouseButtonClick;
        public static bool exitGame = false;
        public static bool removeScreen = false;
        public static bool spawnOutro = false;
        private bool mortenLives = true;
        private bool cameraExists = false;
        public static float mouseX;
        public static float mouseY;
        public static bool win;
        public static bool restart = false;
        public static Vector2 mousePosition;
        private SpriteFont standardSpriteFont;

#if DEBUG
        public Texture2D collisionTexture;
#endif
        #endregion
        /// <summary>
        /// Property to get/set the position of the camera, in this case relative to the players position
        /// </summary>

        #region Properties

        public static Camera2D Camera { get => camera; set => camera = value; }

        #endregion

        #region Constructor

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            if (!cameraExists)
            {
                _graphics.PreferredBackBufferWidth = 1920;
                _graphics.PreferredBackBufferHeight = 1080;
                //_graphics.IsFullScreen = true;
                _graphics.ApplyChanges();
                camera = new Camera2D(GraphicsDevice, Vector2.Zero);
                cameraExists = true;
            }

            // TODO: Add your initialization logic here
#if DEBUG
            gameObjects.Add(new PowerUp(new Vector2(150, 700), 0));
            gameObjects.Add(new PowerUp(new Vector2(450, 700), 1));
            gameObjects.Add(new PowerUp(new Vector2(750, 700), 2));
#endif
            //gameObjects.Add(new Player());
            gameObjects.Add(new IntroScreen());
            gameObjects.Add(new MousePointer(_graphics));
            gameObjects.Add(new CharacterGenerator());
            gameObjects.Add(new Enemy());
            gameObjects.Add(new Overlay());
            gameObjects.Add(new Background(1));
            gameObjects.Add(new Background(2));
            gameObjects.AddRange(new Environment(_graphics).Surfaces); //Adding the environment to gameObjects
            gameObjects.Add(new KeybindingsOverlay());
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (GameObject gameObj in gameObjects)
            { gameObj.LoadContent(Content); }
#if DEBUG
            collisionTexture = Content.Load<Texture2D>("pixel");
            standardSpriteFont = Content.Load<SpriteFont>("standardSpriteFont");
#endif
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (exitGame)
                Exit();
            if (restart)
                Restart();

            if (removeScreen)
            {
                foreach (GameObject gameObj in gameObjects)
                {
                    if (gameObj is IntroScreen || gameObj is Button)
                    {
                        gameObj.Health = 0;
                    }
                }
                removeScreen = false;
            }
            var mouseState = Mouse.GetState();

            mousePosition = new Vector2(mouseState.X, mouseState.Y);

            leftMouseButtonClick = mouseState.LeftButton == ButtonState.Pressed;

            // TODO: Add your update logic here
            mortenLives = false;
            foreach (GameObject gameObject in gameObjects)
            {
                //Surface don't need to run Update() unless they are AvSurface, so this if, makes them continue to save resources.
                if ((gameObject is Surface) && !(gameObject is AvSurface))
                {
                    continue;
                }
                foreach (GameObject other in gameObjects)
                {
                    //An object should not be able to collide with a member of the same class
                    if (gameObject == other)
                    {
                        continue;
                    }
                    //Only Player, MousePointer, Enemy and Ammo needs to check for collisions, so GameOjects of any other class will now need to complete the loop
                    if (!((gameObject is Player) || (gameObject is MousePointer) || (gameObject is Enemy) || (gameObject is Ammo)))
                    {
                        continue;
                    }
                    if (gameObject is MousePointer && other is Button)
                    {
                        gameObject.CheckCollision(other);
                        other.CheckCollision(gameObject);
                    }

                    if (gameObject is Player)
                    {
                        if (other is Enemy || other is Surface || other is PowerUp)
                        {
                            gameObject.CheckCollision(other);
                            other.CheckCollision(gameObject);
                        }
                    }
                    else if (gameObject is Enemy)
                    {
                        if (other is Surface || other is Ammo)
                        {
                            gameObject.CheckCollision(other);
                            other.CheckCollision(gameObject);
                        }
                    }
                    else if (gameObject is Ammo)
                    {
                        if (other is Surface || other is Enemy)
                        {
                            gameObject.CheckCollision(other);
                            other.CheckCollision(gameObject);
                        }
                    }
                }
                gameObject.Update(gameTime);

                if (gameObject is Player || gameObject is CharacterGenerator || gameObject is OutroScreen)
                    mortenLives = true;
                //if (gameObject is OutroScreen && !spawnOutro)
                //{
                //    gameObject.LoadContent(Content);
                //    spawnOutro = true;
                //}
            }
            foreach (GameObject newGameObject in newGameObjects)
            {
                newGameObject.LoadContent(Content);
                gameObjects.Add(newGameObject);
            }
            newGameObjects.Clear();

            gameObjects.RemoveAll(gameObject => gameObject.Health < 1);
            //spawn Outroscreen
            if (!mortenLives)
            {
                //spawnOutro = true;
                newGameObjects.Add(new OutroScreen(Camera.Position));
            }

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
#if DEBUG
                if (!(gameObject is Overlay) && !(gameObject is KeybindingsOverlay)) //Overlay doesn't have sprite declared, so it will give an exception, when trying to draw collisionbox.
                    DrawCollisionBox(gameObject);
                if (gameObject is Surface)
                {
                    DrawLeftSideCollisionBox((gameObject as Surface));
                    DrawRightSideCollisionBox((gameObject as Surface));
                }
#endif
            }
#if DEBUG
            _spriteBatch.DrawString(standardSpriteFont, $"X: {mouseX}\nY: {mouseY}", new Vector2(Camera.Position.X, Camera.Position.Y - 400), Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 1f);

#endif


            _spriteBatch.End();

            base.Draw(gameTime);
        }

#if DEBUG
        private void DrawCollisionBox(GameObject gameObject)
        {
            Rectangle collisionBox = gameObject.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
        }

        private void DrawLeftSideCollisionBox(Surface surface)
        {
            Rectangle collisionBox = surface.LeftSideCollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
        }

        private void DrawRightSideCollisionBox(Surface surface)
        {
            Rectangle collisionBox = surface.RightSideCollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
            _spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1f);
        }
#endif
        public void Restart()
        {
            gameObjects.RemoveAll(gameObject => gameObject.Health > 0);
            Initialize();
            restart = false;
            spawnOutro = false;
        }

        #endregion
    }
}

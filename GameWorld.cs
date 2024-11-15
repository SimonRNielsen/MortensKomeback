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

        #region Properties

        /// <summary>
        /// Property to get/set the position of the camera, in this case relative to the players position
        /// </summary>
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

            gameObjects.Add(new PowerUp(new Vector2(5655, -1385), 0)); //Over first platform 
            gameObjects.Add(new PowerUp(new Vector2(24871, 850), 1)); //Hidden
            gameObjects.Add(new PowerUp(new Vector2(12345, -690), 1)); //Over a hiddden area
            #region Power Up Cathedral
            gameObjects.Add(new PowerUp(new Vector2(30003, -103), 1));
            gameObjects.Add(new PowerUp(new Vector2(29983, 533), 0));
            gameObjects.Add(new PowerUp(new Vector2(29740, -797), 2));
            gameObjects.Add(new PowerUp(new Vector2(30280, -810), 2));
            #endregion

            //gameObjects.Add(new Player());
            gameObjects.Add(new IntroScreen());
            gameObjects.Add(new MousePointer(_graphics));
            gameObjects.Add(new CharacterGenerator());

            #region Add enemies
            gameObjects.Add(new Enemy(new Vector2(1000, 1100)));
            gameObjects.Add(new Enemy(new Vector2(4100, 1100)));
            gameObjects.Add(new Enemy(new Vector2(5444, -1330)));
            gameObjects.Add(new Enemy(new Vector2(7370, 1050)));
            gameObjects.Add(new Enemy(new Vector2(8291, 1100)));
            gameObjects.Add(new Enemy(new Vector2(9234, 1100)));
            gameObjects.Add(new Enemy(new Vector2(10632, 1100)));
            gameObjects.Add(new Enemy(new Vector2(12071, -340)));
            gameObjects.Add(new Enemy(new Vector2(12231, 820)));
            gameObjects.Add(new Enemy(new Vector2(14446, 1100)));
            gameObjects.Add(new Enemy(new Vector2(15494, 1100)));
            gameObjects.Add(new Enemy(new Vector2(16078, 1100)));
            gameObjects.Add(new Enemy(new Vector2(18789, 249)));
            gameObjects.Add(new Enemy(new Vector2(21671, 444)));
            gameObjects.Add(new Enemy(new Vector2(24880, -600)));
            gameObjects.Add(new Enemy(new Vector2(26077, 419)));
            gameObjects.Add(new Enemy(new Vector2(25591, 1100)));
            gameObjects.Add(new Enemy(new Vector2(26403, 1100)));
            gameObjects.Add(new Enemy(new Vector2(28104, 997)));
            gameObjects.Add(new Enemy(new Vector2(31510, -200)));
            gameObjects.Add(new Enemy(new Vector2(32721, -200)));
            gameObjects.Add(new Enemy(new Vector2(34356, 1100)));
            gameObjects.Add(new Enemy(new Vector2(34586, 1100)));
            gameObjects.Add(new Enemy(new Vector2(34807, 1100)));
            gameObjects.Add(new Enemy(new Vector2(36414, -175)));
            gameObjects.Add(new Enemy(new Vector2(37876, -429)));
            gameObjects.Add(new Enemy(new Vector2(38767, -925)));
            gameObjects.Add(new Enemy(new Vector2(39481, -1367)));
            #endregion

            gameObjects.Add(new Overlay());
            
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
            Overlay.KillCount = 0;
            Overlay.PlayerAmmoCount = 0;
            Initialize();
            restart = false;
            spawnOutro = false;
            win = false;
        }

        #endregion
    }
}

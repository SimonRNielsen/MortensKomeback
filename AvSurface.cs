using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class AvSurface : Surface
    {

        #region field
        private int startSprite = 0; //It's starting with sprite 0


        #endregion

        #region properties
        /// <summary>
        /// The collisionbox is set lower than CollisionBox at Surface because the collision is happing midt flame
        /// </summary>
        public override Rectangle CollisionBox
        {
            get { return new Rectangle((int)(Position.X - (Sprite.Width / 2) + 25), (int)Position.Y , Sprite.Width - 50, Sprite.Height / 2); }
        }

        #endregion

        #region constructor
        public AvSurface(GraphicsDeviceManager graphics, Vector2 position, int numberSprite) : base(graphics, position, numberSprite)
        {
            this.startSprite = numberSprite;
            this.health = 1;
            this.fps = 2f; 
            this.layer = 0.1f;
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content) 
        {
            sprites = new Texture2D[4];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("Sprite\\avsurfaceILD" + (i + 1));
            }

            //Start sprite
            this.Sprite = sprites[startSprite];
        }


        public override void OnCollision(GameObject gameObject)
        {
            //Nothing is happening to the AvSurface when it's colliding 
        }

        /// <summary>
        /// Updating AvSurface with Animation
        /// </summary>
        /// <param name="gameTime">A GameTime</param>
        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
        }

        /// <summary>
        /// It's used to create a AvSurface in Environment
        /// </summary>
        /// <param name="graphics">A colliding</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        public static AvSurface Create(GraphicsDeviceManager graphics, float x, float y)
        {
            return new AvSurface(graphics, new Vector2(x, y), 1);
        }



        #endregion

    }
}

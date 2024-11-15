using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class Surface : GameObject
    {
        #region field
        private int spriteID; //Which sprite is going to be used

        #endregion

        #region properties
        public override Rectangle CollisionBox
        {
            get { return new Rectangle((int)(Position.X - (Sprite.Width / 2) + 25), (int)Position.Y - (Sprite.Height / 2), Sprite.Width - 50, Sprite.Height); }
        }

        public Rectangle LeftSideCollisionBox
        {
            get { return new Rectangle((int)Position.X - ((Sprite.Width / 2) + 2), (int)Position.Y - (Sprite.Height / 2) + 15, 2, (Sprite.Height) - 30); }
        }

        public Rectangle RightSideCollisionBox
        {
            get { return new Rectangle((int)Position.X + ((Sprite.Width / 2) + 2), (int)Position.Y - (Sprite.Height / 2) + 15, 2, (Sprite.Height) - 30); }
        }

        #endregion

        #region constructor
        public Surface(GraphicsDeviceManager graphics, Vector2 position, int spriteID)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
            this.layer = 0.3f;
            this.spriteID = spriteID;
            this.health = 1;
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[7];

            sprites[0] = content.Load<Texture2D>("Sprite\\dirt_tile1");
            sprites[1] = content.Load<Texture2D>("Sprite\\grass_tile1");
            sprites[2] = content.Load<Texture2D>("Sprite\\cloud5");
            sprites[3] = content.Load<Texture2D>("Sprite\\cloud3");
            sprites[4] = content.Load<Texture2D>("Sprite\\transparentTile");
            sprites[5] = content.Load<Texture2D>("Sprite\\table");
            sprites[6] = content.Load<Texture2D>("wallTurkey");
            
            this.Sprite = sprites[spriteID];

            if (spriteID == 3 || spriteID == 2)
            {
                spriteEffectIndex = 2; //FlipVertically
            }
        }


        public override void OnCollision(GameObject gameObject)
        {
            //Nothing is happening to the Surface when it's colliding 
        }

        public override void Update(GameTime gameTime)
        {
            //Nothing is updating
        }

        /// <summary>
        /// It's used to create a surface in Environment
        /// </summary>
        /// <param name="graphics">A GraphicsDeviceManager</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">Whice sprite is going to be showed</param>
        /// <returns></returns>
        public static Surface Create(GraphicsDeviceManager graphics, float x, float y, int spriteId)
        {
            return new Surface(graphics, new Vector2(x, y), spriteId);
        }
        #endregion
    }
}
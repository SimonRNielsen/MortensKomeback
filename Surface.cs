using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Surface : GameObject
    {
        #region field
        private GraphicsDeviceManager _graphics;
        private int spriteID; //Which sprite is going to be used


        #endregion

        #region properties
        public Rectangle LeftSideCollisionBox
        {
            get { return new Rectangle((int)Position.X - ((Sprite.Width / 2) + 2), (int)Position.Y - ((Sprite.Height / 2) + 2), 2, (Sprite.Height) - 4); }
        }

        public Rectangle RightSideCollisionBox
        {
            get { return new Rectangle((int)Position.X + ((Sprite.Width / 2) + 2), (int)Position.Y - ((Sprite.Height / 2) + 2), 2, (Sprite.Height) - 4); }
        }

        #endregion

        #region constructor
        public Surface(GraphicsDeviceManager graphics, Vector2 position, int spriteID)
        {
            this._graphics = graphics;
            this.position.X = position.X;
            this.position.Y = position.Y;
            this.layer = 0.9f;
            this.spriteID = spriteID;
            this.health = 1;
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[6];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("Sprite\\tile" + (i + 1));
            }

            //Choosen sprite
            this.Sprite = sprites[spriteID - 1];
        }


        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// It's used to create a surface in Environment
        /// </summary>
        /// <param name="graphics"></param>
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

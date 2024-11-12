using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Surface : GameObject
    {
        #region field
        private int spriteID; //Which sprite is going to be used
        private static Texture2D sprite1;
        private static Texture2D sprite2;
        private static Texture2D sprite3;
        private static Texture2D sprite4;
        private static Texture2D sprite5;
        #endregion

        #region properties
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
            this.layer = 0.1f;
            this.spriteID = spriteID;
            this.health = 1;
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content)
        {
            
            if(sprite1 == default)
            {
                sprite1 = content.Load<Texture2D>("Sprite\\dirt_tile1");
            }
            if(sprite2 == default)
            {
                sprite2 = content.Load<Texture2D>("Sprite\\grass_tile1");
            }
            if (sprite3 == default)
            {
                sprite3 = content.Load<Texture2D>("Sprite\\cloud5");
            }
            if (sprite4 == default)
            {
                sprite4 = content.Load<Texture2D>("Sprite\\cloud3");
            }
            if (sprite5 == default)
            {
                sprite5 = content.Load<Texture2D>("Sprite\\mitre");
            }

            if (spriteID == 1)
            {
                this.Sprite = sprite1;
            }
            if (spriteID == 2)
            {
                this.Sprite = sprite2;
            }
            if (spriteID == 3)
            {
                this.Sprite = sprite3;
                spriteEffectIndex = 2;
            }
            if (spriteID == 4)
            {
                this.Sprite = sprite4;
                spriteEffectIndex = 2;
            }
            if (spriteID == 5)
            {
                this.Sprite = sprite5;
            }
        }


        public override void OnCollision(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
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
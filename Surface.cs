using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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
        private Rectangle collisionBox;
        private int numberSprite; //Which sprite is going to be used


        #endregion

        #region properties

        #endregion

        #region constructor
        public Surface(GraphicsDeviceManager graphics, Vector2 position, int numberSprite)
        {
            this._graphics = graphics;
            this.position.X = position.X;
            this.position.Y = position.Y;
            this.layer = 1f;
            this.numberSprite = numberSprite;
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


            //Default sprite
            this.sprite = sprites[numberSprite-1];
            collisionBox = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }


        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
        public static Surface Create(GraphicsDeviceManager graphics,float x, float y, int spriteId)
        {
            return new Surface(graphics, new Vector2(x, y), spriteId);
        }


        #endregion
    }
}

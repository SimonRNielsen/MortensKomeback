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
    internal class AvSurface : Surface
    {

        #region field
        private GraphicsDeviceManager _graphics;
        private Rectangle collisionBox;
        private int numberSprite = 1; //Which sprite is going to be used


        #endregion

        #region properties

        #endregion

        #region constructor
        public AvSurface(GraphicsDeviceManager graphics, Vector2 position, int numberSprite) : base(graphics, position, numberSprite)
        {
            this._graphics = graphics;
            this.position.X = position.X;
            this.position.Y = position.Y;
            this.layer = 0.1f;
            this.numberSprite = numberSprite;
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
            this.Sprite = sprites[numberSprite - 1];
        }


        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
        }
        public static AvSurface Create(GraphicsDeviceManager graphics, float x, float y)
        {
            return new AvSurface(graphics, new Vector2(x, y), 1);
        }



        #endregion

    }
}

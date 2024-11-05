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
    internal class Surface : Environment
    {
        #region field
        private GraphicsDeviceManager _graphics;
        //private Texture2D sprite;
        //private Texture2D[] sprites;
        //private Vector2 position;
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
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[6];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("Sprite\\tile" + i);
            }


            //Default sprite
            this.sprite = sprites[numberSprite];
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

        //public string selectSprite(int number)
        //{
        //    switch (number)
        //    {
        //        case 1:
        //            return "Sprite\\tile1";
        //        case 2:
        //            return "Sprite\\tile2";
        //        case 3:
        //            return "Sprite\\tile3";
        //        case 4:
        //            return "Sprite\\tile4";
        //        case 5:
        //            return "Sprite\\tile5";
        //        default:
        //            return "Sprite\\tile6";
        //    }
        //}

        #endregion
    }
}

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
        private int startSprite = 0; //It's starting with sprite 0


        #endregion

        #region properties

        #endregion

        #region constructor
        public AvSurface(GraphicsDeviceManager graphics, Vector2 position, int numberSprite) : base(graphics, position, numberSprite)
        {
            this.startSprite = numberSprite;
            this.health = 1;
            this.fps = 0.07f; //Not sure if it's the correkt amount
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

            //Start sprite
            this.Sprite = sprites[startSprite];
        }


        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Updating AvSurface with Animation
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
        }

        /// <summary>
        /// It's used to create a AvSurface in Environment
        /// </summary>
        /// <param name="graphics"></param>
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

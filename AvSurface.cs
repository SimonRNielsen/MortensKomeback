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
        /// <summary>
        /// The collisionbox is set lower than CollisionBox at Surface because the collision is happ
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
            this.fps = 2f; //Not sure if it's the correkt amount
            this.layer = 0f;
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

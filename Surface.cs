using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Surface
    {
        #region field
        private GraphicsDeviceManager _graphics;
        private Texture2D sprite;
        private Texture2D[] sprites;
        private Vector2 surfacePosition;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Surface(GraphicsDeviceManager graphics, Vector2 position)
        {
            this._graphics = graphics;
            surfacePosition.X = position.X;
            surfacePosition.Y = position.Y;
        }

        #endregion

        #region method

        public void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[6];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("tile" + i);
            }


            //Default sprite
            this.sprite = sprites[0];
        }


        public void OnCollision(GameObject other)
        {
            
        }

        #endregion


    }
}

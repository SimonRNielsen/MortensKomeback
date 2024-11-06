using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace MortensKomeback
{
    internal class Background : GameObject
    {
        #region field
        private GraphicsDeviceManager _graphics;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background(GraphicsDeviceManager graphics)
        {
            this._graphics = graphics;
            this.layer = 0f;
            this.scale = 1f;
            this.position.X = 1;
            this.position.Y = 1;


            //this.layer = 0.9f;
            this.health = 1;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("Sprite\\backgroundTEst");
        }

        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        #endregion


    }
}

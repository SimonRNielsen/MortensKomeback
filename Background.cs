using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class Background : Environment
    {
        #region field
        private GraphicsDeviceManager _graphics;
        //private Texture2D sprite;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background(GraphicsDeviceManager graphics)
        {
            this._graphics = graphics;
            this.layer = 0f;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprite\\tile1");
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

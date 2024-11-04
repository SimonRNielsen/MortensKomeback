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
    internal class Background
    {
        #region field
        private GraphicsDeviceManager _graphics;
        private Texture2D sprite;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background(GraphicsDeviceManager graphics)
        {
            this._graphics = graphics;
            GameObject.layer = 0f;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("background tester");
        }

        #endregion


    }
}

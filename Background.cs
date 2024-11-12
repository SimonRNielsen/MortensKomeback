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

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background()
        {
            this.layer = 0f;
            this.scale = 1f;
            this.position.X = 1;
            this.position.Y = 1;
            this.health = 1;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background in to content
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("Sprite\\backgroundTEst");
        }

        /// <summary>
        /// Tjecking if a gameobject is collidering but there is not anything going to happens to the Background
        /// </summary>
        /// <param name="gameObject">The gameobject it's collidering woth</param>
        public override void OnCollision(GameObject gameObject)
        {
            //Nothing is going to happens
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Nothing is going to happens
        }

        #endregion


    }
}

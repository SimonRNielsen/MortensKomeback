using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Player : GameObject
    {
        #region Fields
        private Texture2D[] ammoSprites;
        private SoundEffect shootSound;
        private SoundEffect takeDamageSound;

        #endregion

        #region Properties
        #endregion


        #region Constructor
        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A method, that handles player input. WASD moves the player, and space makes it shoot. 
        /// </summary>
        private void HandeInput()
        {

        }

        #endregion

    }
}

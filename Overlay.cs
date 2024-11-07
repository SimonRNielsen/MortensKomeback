using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Overlay : GameObject
    {
        #region Fields
        private Texture2D healthSprite;
        private Texture2D killsSprite;
        private Texture2D ammoSprite;
        private Texture2D[] ammoSprites;
        public static int healthCount;
        public static int playerAmmoCount;
        private Rectangle ammoRectangle;

        #endregion
        #region Cosntructor
        public Overlay()
        {
        }

        #endregion

        /// <summary>
        /// Loads the neccessary sprites for the Overlay
        /// </summary>
        /// <param name="content">Contentmanager from GameWorld</param>
        public override void LoadContent(ContentManager content)
        {
            killsSprite = content.Load<Texture2D>("goose1");
            ammoSprites = new Texture2D[2] { content.Load<Texture2D>("egg1"), content.Load<Texture2D>("egg2") };
            ammoSprite = ammoSprites[0];
            ammoRectangle = new Rectangle(0, 0, ammoSprite.Width, ammoSprite.Height);

        }
        /// <summary>
        /// OnCollision for Overlay, should not have any functionality. It is just a result of the method being abstract 
        /// and inherited from GameObject.
        /// </summary>
        /// <param name="gameObject"></param>
        public override void OnCollision(GameObject gameObject)
        {
        }
        /// <summary>
        /// Update function that continually is called, as long as the Overlay is in GameWorlds gameObjects list.
        /// </summary>
        /// <param name="gameTime">GameTime, given by GameWorld</param>
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ammoSprite)
        }
    }
}

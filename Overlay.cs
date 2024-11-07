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
        private Vector2 ammoPosition;
        private Vector2 killsPosition;
        private Vector2 healthPosition;

        #endregion
        #region Cosntructor
        public Overlay()
        {
            this.health = 1;
            ammoPosition.Y = -500;
            ammoPosition.X = -300;
            killsPosition.Y = -450;
            killsPosition.X = -300;
            healthPosition.Y = -400;
            healthPosition.X = -300;

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
            ammoPosition.X = GameWorld.Camera.Position.X;
         
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ammoSprite, ammoPosition, Color.White);
            spriteBatch.Draw(killsSprite, killsPosition, Color.White);

        }
    }
}

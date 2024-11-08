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
    /// <summary>
    /// A graphical overlay on the screeen, that shows the players health, ammo and killcount. 
    /// </summary>
    internal class Overlay : GameObject
    {
        #region Fields
        private Texture2D healthSprite;
        private Texture2D killsSprite;
        private Texture2D ammoSprite;
        private Texture2D[] ammoSprites;
        //Players health. Is public static, so it can be affected by other classes, like the player
        public static int healthCount;
        //Players ammo. Is public static, so it can be affected by other classes, like the player
        public static int playerAmmoCount;
        //Count players kills. Is public static, so it can be affected by other classes, like the an enemy when it is killed.
        public static int killCount;
        private Vector2 ammoPosition;
        private Vector2 killsPosition;
        private Vector2 healthPosition;
        private SpriteFont mortalKombatFont;

        #endregion
        #region Cosntructor
        /// <summary>
        /// Overlays constructor. Sould be added to gameObjects in gameworld, when the game is initialised. 
        /// </summary>
        public Overlay()
        {
            this.health = 1;
            //Default positions for the overlay items. 
            ammoPosition.Y = -540;
            ammoPosition.X = -960;
            killsPosition.Y = -500;
            killsPosition.X = -960;
            healthPosition.Y = -460;
            healthPosition.X = -960;
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
            mortalKombatFont = content.Load<SpriteFont>("mortalKombatFont");
            healthSprite = content.Load<Texture2D>("heartSprite");

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
            //Positions for the overlay items, a positioned relative to the camera position, and the zoom, so it will stay in the same position
            //event when the player is moving. 
            ammoPosition.X = GameWorld.Camera.Position.X - (930 / GameWorld.Camera.Zoom);
            killsPosition.X = GameWorld.Camera.Position.X - (930 / GameWorld.Camera.Zoom);
            ammoPosition.Y = -(520 / GameWorld.Camera.Zoom);
            killsPosition.Y = -(480 / GameWorld.Camera.Zoom);
            healthPosition.X = GameWorld.Camera.Position.X - (955 / GameWorld.Camera.Zoom);
            healthPosition.Y = -(460 / GameWorld.Camera.Zoom);

            //Sets the ammosprite depending on ammocount. If ammocount is over 0, it means that the player is using special ammo, and
            //therefore ammosprite must cahnge to reflect this. 
            if (playerAmmoCount > 0)
            {
                ammoSprite = ammoSprites[1];
            }
            else if (playerAmmoCount == 0)
            {
                ammoSprite = ammoSprites[0];
            }
        }
        /// <summary>
        /// Draws the overlay on the screen
        /// </summary>
        /// <param name="spriteBatch">Spritebatch from GameWorld.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ammoSprite, ammoPosition, null, Color.White, 0, origin, 1.5f, SpriteEffects.None, 0.9f);
            spriteBatch.Draw(killsSprite, killsPosition, null, Color.White, 0, origin, 0.5f, SpriteEffects.None, 0.9f);
            spriteBatch.Draw(killsSprite, killsPosition, null, Color.White, 0, origin, 0.5f, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(mortalKombatFont, $"Kills: {killCount}", new Vector2(killsPosition.X + 75, killsPosition.Y + (killsSprite.Height / 4)), Color.Black, 0f, new Vector2(0, 5), 3f, SpriteEffects.None, 0.9f);
            //Draws the text for ammocount. If ammocount is 0, standard ammo is used, and ammo is endless. 
            if (playerAmmoCount > 0)
            {
                spriteBatch.DrawString(mortalKombatFont, $"Ammo: {playerAmmoCount}", new Vector2(ammoPosition.X + 75, ammoPosition.Y + (ammoSprite.Height / 4)), Color.Black, 0f, new Vector2(0, 5), 3f, SpriteEffects.None, 0.9f);
            }
            else
            {
                spriteBatch.DrawString(mortalKombatFont, $"Ammo: infinite", new Vector2(ammoPosition.X + 75, ammoPosition.Y + (ammoSprite.Height / 4)), Color.Black, 0f, new Vector2(0, 5), 3f, SpriteEffects.None, 0.9f);
            }
            //Health is represented by hearts. This switch draws hearts depending on players healthcount. 
            switch (healthCount)
            {
                case 3:
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X - 50, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X + 50, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X + 150, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    break;
                case 2:
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X - 50, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X + 50, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    break;
                case 1:
                    spriteBatch.Draw(healthSprite, new Vector2(healthPosition.X - 50, healthPosition.Y), null, Color.White, 0, origin, 4f, SpriteEffects.None, 0.9f);
                    break;
            }

        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class PowerUp : GameObject
    {

        private int powerUpType;

        /// <summary>
        /// Powerup Creator
        /// </summary>
        /// <param name="placement">X and Y vector placement for spawning the item</param>
        /// <param name="type">0 for ammo PowerUp, 1 for healing PowerUp</param>
        public PowerUp(Vector2 placement, int type)
        {

            this.powerUpType = type;
            this.position = placement;
            this.health = 1;
            this.layer = 0.2f;

        }

        /// <summary>
        /// Loads sprites for powerups
        /// </summary>
        /// <param name="content">Contentmanager</param>
        public override void LoadContent(ContentManager content)
        {

            sprites = new Texture2D[2];
            this.sprites[0] = content.Load<Texture2D>("egg2");
            //this.sprites[1] = content.Load<Texture2D>("");
            try
            {
                this.sprite = sprites[powerUpType];
            }
            catch (IndexOutOfRangeException)
            {
                this.sprite = sprites[0];
            }
            this.position.Y -= sprite.Height / 2;

        }

        /// <summary>
        /// Applies effects on Player
        /// </summary>
        /// <param name="gameObject">Player</param>
        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Player)
            {

                this.health--;

                if (powerUpType == 0)
                {
                    (gameObject as Player).OverPowered();
                }

                if (powerUpType == 1)
                {
                    gameObject.Health = 3;
                }

            }

        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}

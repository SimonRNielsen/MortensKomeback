using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MortensKomeback
{
    internal class PowerUp : GameObject
    {

        private int powerUpType;
        private bool attach = false;
        private float duration = 5f;
        private float timer;
        Random random = new Random();
        SoundEffect powerUpSound;

        /// <summary>
        /// Powerup Creator
        /// </summary>
        /// <param name="placement">X and Y vector placement for spawning the item</param>
        /// <param name="type">0 for ammo PowerUp, 1 for healing PowerUp, above 1 for random</param>
        public PowerUp(Vector2 placement, int type)
        {

            if (type > 2)
                type = random.Next(0, 3);
            this.powerUpType = type;
            this.position = placement;
            this.health = 1;
            this.layer = 0.91f;

        }

        /// <summary>
        /// Loads sprites for powerups
        /// </summary>
        /// <param name="content">Contentmanager</param>
        public override void LoadContent(ContentManager content)
        {

            sprites = new Texture2D[3];
            this.sprites[0] = content.Load<Texture2D>("egg2");
            this.sprites[1] = content.Load<Texture2D>("wallTurkey");
            this.sprites[2] = content.Load<Texture2D>("Sprite\\mitre");
            this.sprite = sprites[powerUpType];
            this.position.Y -= sprite.Height / 2;
            powerUpSound = content.Load<SoundEffect>("powerUp_Sound");
        }

        /// <summary>
        /// Applies effects on Player
        /// </summary>
        /// <param name="gameObject">Player</param>
        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Player)
            {
                powerUpSound.Play();
                this.health--;

                if (powerUpType == 0)
                {
                    this.health--;
                    (gameObject as Player).OverPowered();
                }

                if (powerUpType == 1)
                {
                    this.health--;
                    if (gameObject.Health < 3)
                    {
                        gameObject.Health++;
                    }
                }

                if (powerUpType == 2 && !attach)
                {
                    (gameObject as Player).InvulnerablePowerUp();
                    this.attach = true;
                }

            }

        }

        public override void Update(GameTime gameTime)
        {
            if (this.powerUpType == 2 && attach)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.position.X = GameWorld.Camera.Position.X - 12;
                this.position.Y = GameWorld.Camera.Position.Y - 150;
                if (timer >= duration)
                {
                    this.health--;
                }
            }
        }
    }
}

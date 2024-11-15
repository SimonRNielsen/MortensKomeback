using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace MortensKomeback
{
    internal class Ammo : GameObject
    {
        #region Fields

        Random random = new Random(); //Used for random "on hit" sprite
        private float timer = 0f;
        private float collisionTimer = 4f;
        private bool collided = false;
        private bool flipped = false;

        #endregion

        #region Property
        public bool Collided { get => collided; set => collided = value; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for "spawning" eggs that Morten shoots with his sling
        /// </summary>
        /// <param name="player">Accesses the player class for relative spawning position and for the sprites used</param>
        /// <param name="ammoHealth">Determines how effective the ammo is, dependant on Morten picking up powerups or not</param>
        /// <param name="ammoSprite">Determines how Mortens ammo looks like when he shoots it</param>
        public Ammo(Player player, int ammoHealth, int ammoSprite)
        {
            this.Health = ammoHealth;
            position.Y = player.Position.Y + 2;
            if (player.Flipped)
            {
                position.X = player.Position.X - (player.Sprite.Width / 2);
                this.velocity.X = -1f;
                this.flipped = player.Flipped;
            }
            else
            {
                position.X = player.Position.X + (player.Sprite.Width / 2);
                this.velocity.X = 1;
            }
            this.Speed = player.Speed + 200f;
            this.layer = 0.9f;
            this.sprites = player.AmmoSprites;
            this.sprite = sprites[ammoSprite];
            this.deathSoundEffect = player.AmmoSound; 
        }


        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Content loaded by Player class
        }

        /// <summary>
        /// Handles how the Ammo behaves on impact according to hitting either an Enemy, Surface or nothing
        /// </summary>
        /// <param name="gameObject">Other object being collided with</param>
        public override void OnCollision(GameObject gameObject)
        {
            /*
            try
            {
            */
            if (gameObject is Surface || gameObject is Enemy)
            {
                if (this.health == 1)
                {

                    if (gameObject is Surface && !Collided)
                    {
                        this.Collided = true;
                        timer = 0f;
                        this.sprite = this.sprites[4];
                        this.rotation = 0f;
                        this.deathSoundEffect.Play();
                    }
                    else if (gameObject is Enemy && !Collided)
                    {
                        this.Collided = true;
                        timer = 0f;
                        this.sprite = this.sprites[random.Next(2, 4)];
                        if (flipped)
                        {
                            this.rotation = 0.25f;
                        }
                        else
                        {
                            this.rotation = -0.25f;
                        }
                        this.deathSoundEffect.Play();
                    }

                }
                else if (gameObject is Enemy && !((gameObject as Enemy).IsHit) && !Collided)
                {
                    this.health--;
                    this.deathSoundEffect.Play();
                    (gameObject as Enemy).IsHit = true;
                }
                else if (!Collided)
                {
                    this.Collided = true;
                    timer = 0f;
                    this.sprite = this.sprites[4];
                    this.rotation = 0f;
                    this.deathSoundEffect.Play();
                }
            }
            /*
            }
            catch (IndexOutOfRangeException)
            {
                this.health = 0;
            }
            */
        }

        /// <summary>
        /// Handles movement and rotation based on which way Morten is looking
        /// </summary>
        /// <param name="gameTime">Timer and syncronization</param>
        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!Collided)
            {

                if (flipped)
                {
                    this.rotation += -0.35f;
                }
                else
                {
                    this.rotation += 0.35f;
                }

                if (timer > 1)
                {
                    this.position.Y += 1;
                }
                if (timer > 2)
                {
                    this.position.Y += 1;
                }
                if (timer > 3)
                {
                    this.position.Y += 2;
                }

                this.Move(gameTime);

            }

            
            
            if (Collided && timer > collisionTimer)
            {
                this.Health = 0;
            }
            if (this.position.Y > 5000)
            {
                this.health = 0;
            }

        }

        #endregion
    }
}

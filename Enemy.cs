using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace MortensKomeback
{
    internal class Enemy : Character
    {
        #region fields
        private bool flipped = false;
        private Vector2 direction;
        private Random rnd = new Random();
        private SpriteEffects spriteEffects;
        protected float distanceToPlayer;
        private Texture2D[] aggroSprite;
        private Texture2D[] normalSprites;
        private bool isHit;
        private float honkCountdown = 1f;
        private float honkTimer;
        private SoundEffect honkSound;
        private bool isAggro = false;
        private static Vector2 playerPosition;
        #endregion

        #region properties
        /// <summary>
        /// Property to get players position to enemy
        /// </summary>
        public static Vector2 PlayerPosition { get => playerPosition; set => playerPosition = value; }

        /// <summary>
        /// Property to acces wheter the enemy has already been hit, so collisions are not counted more than once
        /// </summary>
        public bool IsHit { get => isHit; set => isHit = value; }
        #endregion

        #region Methods

        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 1000;
            this.position.Y = 0;
            this.speed = 250;
            this.velocity = new Vector2(1, 0);
            this.fps = 15f;
            this.Health = 1;
            this.layer = 0.8f;
            this.scale = 1;
            this.IsHit = false;
        }
        /// <summary>
        /// Calculates distances from enemy to player
        /// </summary>
        /// <param name="playerPosition"></param> current position of player
        /// <returns>the distance to player as a float</returns> 
        public float CalculateDistanceToPLayer(Vector2 playerPosition)
        {
            return Vector2.Distance(this.position, playerPosition);

        }


        public override void LoadContent(ContentManager content)
        {
            //Loader sprites til animation
            sprites = new Texture2D[7];
            normalSprites = new Texture2D[7];
            for (int i = 0; i < sprites.Length; i++)
            {
                normalSprites[i] = content.Load<Texture2D>("gooseWalk" + i);
            }

            //Sætter default sprite
            sprites = normalSprites;
            sprite = sprites[0];
            ////Indlæs honk Lyd
            //honkSound = content.Load<SoundEffect>("gooseSound_cut");


            //Indlæs honk Lyd
            honkSound = content.Load<SoundEffect>("gooseSound_Short");
            //loader aggro animation 
            aggroSprite = new Texture2D[7]; //sæt til 7
            for (int i = 0; i < aggroSprite.Length; i++)
            {
                aggroSprite[i] = content.Load<Texture2D>("aggro" + i);
            }

        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = false;

            if (gameObject is Surface)
            {
                surfaceContact = true;
            }
            if (gameObject is Ammo && !isHit)
            {
                honkSound.Play();
                this.Health--;
                Overlay.KillCount++;
            }
            if (gameObject is Player && (honkTimer > honkCountdown))
            {
                honkSound.Play();
                honkTimer = 0f;
            }
        }

        public override void Update(GameTime gameTime)
        {
            #region flip enemy
            // Inverter sprite horisontalt, hvis fjenden ændrer retning
            if (velocity.X == 1)
            {
                spriteEffectIndex = 1;
            }
            else
            {
                spriteEffectIndex = 0;
            }

            //We find distance to player, and set "aggro"
            distanceToPlayer = CalculateDistanceToPLayer(PlayerPosition);

            if (distanceToPlayer <= 1000f)
            {
                speed = 500;
                sprite = aggroSprite[0];
                sprites = aggroSprite;

                if (!isAggro)
                {
                    position.Y -= 20;
                    isAggro = true;
                }
            }
            else
            {
                speed = 200;
                sprite = sprites[0];
                sprites = new Texture2D[normalSprites.Length];
                sprites = normalSprites;
                isAggro = false;
            }

            //counter gravity
            velocity = new Vector2(velocity.X, 0); 
            
            base.Update(gameTime);

            Animate(gameTime);
            Move(gameTime);

            honkTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            #endregion
        }

      
        #endregion
    }
}

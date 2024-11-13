using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Enemy : Character
    {
        #region fields
        private List<Texture2D> spriteEnemy = new List<Texture2D>();
        private SoundEffect takeDamageSound;
        private SoundEffect honkSound;
        private bool flipped = false;
        private Vector2 direction;
        private Random rnd = new Random();
        private SpriteEffects spriteEffects;
        private bool isHit;

       
        #endregion


        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 2580;
            this.position.Y = 0;
            this.speed = 250;
            this.velocity = new Vector2(1, 0);
            this.fps = 15f;
            this.Health = 1;
            this.layer = 0.8f;
            this.scale = 1;
        }
        /// <summary>
        /// Property to acces wheter the enemy has already been hit, so collisions are not counted more than once
        /// </summary>
        public bool IsHit { get => isHit;}


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Loader sprites til animation
            sprites = new Texture2D[5];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("gooseWalk" + i);
            }

            //Sætter default sprite
            sprite = sprites[0];


            //Indlæs honk Lyd
            honkSound = content.Load<SoundEffect>("gooseSound_cut");

        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = false;
            // honkSound.Play();

            if (gameObject is Surface)
            {
                surfaceContact = true;
            }
            if (gameObject is Ammo && !isHit)
            {
                honkSound.Play();
                isHit = true;
                this.Health--;
                Overlay.KillCount++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);

            //Fjende movement
            Position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

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
            velocity = new Vector2(velocity.X, 0); 
            
            
            
            base.Update(gameTime);

            Move(gameTime);
            #endregion

        }



        #endregion
    }
}

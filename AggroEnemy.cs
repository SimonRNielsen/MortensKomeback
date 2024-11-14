using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class AggroEnemy : Character
    {
        #region fields
        private List<Texture2D> spriteEnemy = new List<Texture2D>();
        private SoundEffect takeDamageSound;
        private SoundEffect honkSound;
        private bool flipped = false;
        private Vector2 direction;
        private Random rnd = new Random();
        private SpriteEffects spriteEffects;
        private int honk;
        #endregion


        /// <summary>
        /// enemy constructor
        /// </summary>
        public AggroEnemy()
        {
            this.position.X = 280;
            this.position.Y = 0;
            this.speed = 650;
            this.velocity = new Vector2(1, 0);
            this.fps = 5f;
            this.Health = 1;
            this.layer = 0.8f;
            this.scale = 1;
        }


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Loader sprites til animation
            sprites = new Texture2D[4];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("aggro" + i);
            }

            //Sætter default sprite
            sprite = sprites[0];

            //loader aggro animation 
            sprites = new Texture2D[4];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("aggro" + i);
            }

            //Sætter default sprite
            sprite = sprites[0];

            //Indlæs honk Lyd
            honkSound = content.Load<SoundEffect>("gooseSound_cut");
        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = false;

            if (gameObject is Surface)
            {
                surfaceContact = true;
                //honkSound.Play();
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

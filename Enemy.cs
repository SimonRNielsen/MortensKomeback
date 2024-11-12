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
        


        #endregion


        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 580;
            this.position.Y = 0;
            this.speed = 250;
            this.velocity = new Vector2(1, 0);
            this.fps = 1f;
            this.Health = 1;
            this.layer = 1;
            this.scale = 1;
        }


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Loader sprites til animation
            sprites = new Texture2D[5];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("goose" + i);
            }

            //set default sprite
            sprite = sprites[0];


            //Indlæs honk Lyd
            honkSound = content.Load<SoundEffect>("gooseSound_cut");
        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = false;
            // honkSound.Play();
        }

        public override void Update(GameTime gameTime)
        {
            position.X++;
            if (surfaceContact == true)
            {
                honkSound.Play();
            }

            Animate(gameTime);


            #region 
            //Fjende movement i stedet for Move()
            Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Inverter sprite horisontalt, hvis fjenden ændrer retning
            if (velocity.X == 1)
            {
                spriteEffectIndex = 1;
            }
            else
            {
                spriteEffects = SpriteEffects.None;
            }

            velocity = new Vector2(0, 0);

            //Move(gameTime);
            base.Update(gameTime);
            #endregion

        }



        #endregion
    }
}

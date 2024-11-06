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
        private SoundEffect honkSound;
        private List<Texture2D> spriteEnemy = new List<Texture2D>();
        //private Texture2D[] enemySpriteArray = new Texture2D[];
        private Vector2 direction;
        protected static Random rnd = new Random();

        #endregion
        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 0;
            this.position.Y = 0;
            this.speed = 200f;
           
            this.fps = 15f;
            this.Health = 3;
            this.layer = 1;
            this.scale = 1;
            
        }


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("goose1");
           

            //Indlæs 
            spriteEnemy.Add(content.Load<Texture2D>("goose3"));
            spriteEnemy.Add(content.Load<Texture2D>("goose4"));
            spriteEnemy.Add(content.Load<Texture2D>("goose5"));

            //Indlæs Lyd
            honkSound = content.Load<SoundEffect>("gooseSound");
        }

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Move(gameTime);

            //Fjende movement
            Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Fjende move pattern
            if (Position.X < 0 || Position.X > 800) //movementbox skal justeres efter ønske
            {
                direction.X *= -1; //Skifter retning
                honkSound.Play(); //Honk lyd ved retning-skift
            }


            base.Update(gameTime);
        }

        #endregion
    }
}

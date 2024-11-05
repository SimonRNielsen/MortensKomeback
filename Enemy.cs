using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Enemy : Character
    {
        #region fields
        private SoundEffect honkSound;
        //private SoundEffect takeDamageSound;
        private List<Texture2D> spriteEnemy = new List<Texture2D>();
        //private string[] spriteEnemy = new string[] { "goose1", "goose2", "goose3", "goose4", "goose5" };
        private Vector2 direction; //?
        #endregion


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Indlæs animation frames
            spriteEnemy.Add(content.Load<Texture2D>("goose3"));
            spriteEnemy.Add(content.Load<Texture2D>("goose4"));
            spriteEnemy.Add(content.Load<Texture2D>("goose5"));
            

            //Indlæs Lyd
            honkSound = content.Load<SoundEffect>("Goose Sound Effect ProSounds");
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

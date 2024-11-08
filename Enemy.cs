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
        private SoundEffect honkSound;
        private Vector2 direction;
        private Random rnd = new Random();
        private float leftLimit;      //patrulje-grænse venstre
        private float rightLimit;     //patrulje-grænse højre
        private bool flipped = false;
        private float enemyMoveTimer;
        private float enemyHonkTimer;
        #endregion


        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 10;
            this.position.Y = 10;
            this.speed = 250;
            this.velocity = new Vector2(1,0);
            this.fps = 30f;
            this.Health = 3;
            this.layer = 0;
            this.scale = 1;
            this.leftLimit = 100;
            this.rightLimit = 300;
            
        }


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("goose1");
            spriteEnemy.Add(content.Load<Texture2D>("goose3"));
            spriteEnemy.Add(content.Load<Texture2D>("goose4"));
            spriteEnemy.Add(content.Load<Texture2D>("goose5"));

            //Indlæs Lyd
            honkSound = content.Load<SoundEffect>("gooseSound_cut");
        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = true;
        }

        public override void Update(GameTime gameTime)
        {
            enemyHonkTimer++;
            
            velocity = new Vector2(0, 0);



            #region fjendemovement patrulje med pixel afgrænsning
            //Fjende movement i stedet for Move()
            Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.X <= leftLimit)
            {
                direction.X = 1;
                honkSound.Play();
            }
            else if (Position.X >= rightLimit)
            {
                direction.X = -1;
                honkSound.Play();
            }
            #endregion



            //if (enemyHonkTimer == 5f)
            //{ 
            //    honkSound.Play();
            //}

            //Move(gameTime);
            base.Update(gameTime);

        }

        #endregion
    }
}
 
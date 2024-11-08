using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    public abstract class Character : GameObject
    {
        protected bool surfaceContact = false;


        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Gravity(gameTime);
        }

        /// <summary>
        /// Pulls the object downwards if it isn't colliding with a object of the surface class.
        /// </summary>
        /// <param name="gameTime"></param>
        protected void Gravity(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (surfaceContact || position.Y > 500) //|| and after, is because we don't yet have surfaces.
            {

                velocity += new Vector2(0, 0);


                surfaceContact = false;

            }
            else
            {
                velocity += new Vector2(0, 1);
                if (velocity.Y >= 0)
                    position.Y += velocity.Y * 3 * speed * deltaTime;
            }
        }

    }
}

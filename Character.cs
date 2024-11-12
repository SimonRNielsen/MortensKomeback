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
            if (gameObject is Surface)
            {
                surfaceContact = true;
                this.velocity.Y = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Gravity(gameTime);
            if (surfaceContact)
            {
                surfaceContact = false;
            }
        }

        /// <summary>
        /// Pulls the object downwards if it isn't colliding with a object of the surface class.
        /// </summary>
        /// <param name="gameTime"></param>
        protected void Gravity(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!(surfaceContact || position.Y > 500)) //|| and after, is because we don't yet have surfaces.
            {
                if (velocity.Y == 0)
                    velocity.Y += 1;
            }
        }

    }
}

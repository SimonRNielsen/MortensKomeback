using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

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
                this.velocity.Y = 0;
                if ((this.CollisionBox.Y) > (gameObject.CollisionBox.Y-(gameObject.CollisionBox.Height/2)))
                {
                    this.position.Y =  gameObject.CollisionBox.Bottom + (this.Sprite.Height / 1.5f);
                }
                else
                {
                surfaceContact = true;
                }
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

            if (!(surfaceContact))
            {
                if (velocity.Y == 0)
                    velocity.Y += 1;
            }
        }

    }
}

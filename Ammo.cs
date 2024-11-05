using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Ammo : GameObject
    {
        private float timer = 0f;
        private float collisionTimer = 4f;
        private bool collided = false;
        private bool flipped = false;

        public Ammo(Player player)
        {
            this.Health = 1;
            position.Y = player.Position.Y + 50;
            if (player.Flipped)
            {
                position.X = player.Position.X;
                this.velocity.X = -1f;
                this.flipped = player.Flipped;
            }
            else
            {
                position.X = player.Position.X + player.Sprite.Width;
                this.velocity.X = 1;
            }
            this.speed = 500f;
            this.sprites = player.AmmoSprites;
            this.sprite = sprites[0];
        }

        public override void LoadContent(ContentManager content)
        {
            //Content loaded by Player class
        }

        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Surface)
            {
                timer = 0f;
                this.sprite = this.sprites[1];
                this.rotation = 0f;
            }
            else if (gameObject is Enemy)
            {
                timer = 0f;
                this.sprite = this.sprites[1];
                if (flipped)
                {
                    this.rotation = 0.25f;
                }
                else
                {
                    this.rotation = -0.25f;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (flipped)
            {
                this.rotation += -0.35f;
            }
            else
            {
                this.rotation += 0.35f;
            }
            if (timer > 1)
            {
                this.position.Y += 1;
            }
            if (timer > 2)
            {
                this.position.Y += 1;
            }
            if (timer > 3)
            {
                this.position.Y += 2;
            }
            if (collided && timer > collisionTimer)
            {
                this.Health--;
            }

            this.Move(gameTime);
        }
    }
}

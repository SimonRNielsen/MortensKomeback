using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MortensKomeback
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 velocity;
        protected float fps;
        protected float scale = 1f;
        protected float layer;
        protected float speed;
        protected float rotation;
        private float timeElapsed;
        protected SoundEffect deathSoundEffect;
        protected int health;
        private int currentIndex;
        protected int spriteEffectIndex;
        private SpriteEffects[] objectSpriteEffects = new SpriteEffects[2] { SpriteEffects.None, SpriteEffects.FlipHorizontally };




        public Rectangle CollisionBox
        {
            get { return new Rectangle((int)Position.X - (Sprite.Width / 2), (int)Position.Y - (Sprite.Height / 2), Sprite.Width, Sprite.Height); }
        }

        public Vector2 Position { get => position; set => position = value; }

        public Texture2D Sprite { get => sprite; set => sprite = value; }

        public int Health { get => health; set => health = value; }

        public abstract void OnCollision(GameObject gameObject);

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Modified to recieve individual sprite, position, rotation, scale, spriteeffects and layerdepth from each individual gameobject
        /// </summary>
        /// <param name="spriteBatch">Drawing tool</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, objectSpriteEffects[spriteEffectIndex], layer);
        }

        protected void Animate(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentIndex = (int)(timeElapsed * fps);

            Sprite = sprites[currentIndex];

            if (currentIndex >= sprites.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }
        }


        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * speed) * deltaTime);
        }


        public bool IsColliding(GameObject other)
        {
            bool isColliding = false;

            return isColliding;
        }

        /// <summary>
        /// Handles collision with other objects and Player/Enemy movement restrictions in regards to Surface sides
        /// </summary>
        /// <param name="other">Accesses the object being collided with</param>
        public void CheckCollision(GameObject other)
        {
            if (CollisionBox.Intersects(other.CollisionBox))
            {
                OnCollision(other);
            }

            if (this is Player || this is Enemy)
            {

                if (other is Surface)
                {

                    if (CollisionBox.Intersects((other as Surface).LeftSideCollisionBox))
                    {
                        this.position.X = other.Position.X - (other.Sprite.Width/2)-(this.Sprite.Width/2)-1;
                        if (this is Enemy)
                        {
                            this.velocity.X -= 2;
                        }
                    }

                    else if (CollisionBox.Intersects((other as Surface).RightSideCollisionBox))
                    {
                        this.position.X = other.Position.X + (other.Sprite.Width/2)+(this.Sprite.Width/2)+1;
                        if (this is Enemy)
                        {
                            this.velocity.X += 2;
                        }
                    }

                }

            }

        }

        protected static object FindGameObjectWithTag(string v)
        {
            throw new NotImplementedException();
        }
    }
}

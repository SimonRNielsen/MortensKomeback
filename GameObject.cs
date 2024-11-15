using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MortensKomeback
{
    public abstract class GameObject
    {
        #region Fields

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
        protected SpriteEffects[] objectSpriteEffects = new SpriteEffects[3] { SpriteEffects.None, SpriteEffects.FlipHorizontally, SpriteEffects.FlipVertically }; 
        public static bool leftMouseButtonClick;
        public static Vector2 mousePosition;
        private SpriteFont standardSpriteFont;

        #endregion

        #region Properties

        public virtual Rectangle CollisionBox
        {
            get { return new Rectangle((int)Position.X - (Sprite.Width / 2), (int)Position.Y - (Sprite.Height / 2), Sprite.Width, Sprite.Height); }
        }

        public Vector2 Position { get => position; set => position = value; }

        public Texture2D Sprite { get => sprite; set => sprite = value; }

        public int Health { get => health; set => health = value; }
        public float Speed { get => speed;set => speed = value; }

        #endregion

        #region Constructor
        //Can't be constructed
        #endregion

        #region Methods

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

            //if (currentIndex > sprites.Length - 1)
            //    currentIndex = 0;

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
            position += ((velocity * Speed) * deltaTime);
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

        #endregion

    }
}

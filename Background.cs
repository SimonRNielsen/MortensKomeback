using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;

namespace MortensKomeback
{
    internal class Background : GameObject
    {
        #region field
        private int spriteID; //Which sprite is going to be used
        private Song backgroundMusic;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background(int spriteID, int xPosition, int yPosition)
        {
            this.layer = 0f;
            this.scale = 1f;
            this.position.X = xPosition;
            this.position.Y = yPosition;
            this.health = 1;
            this.spriteID = spriteID;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background in to content
        /// </summary>
        /// <param name="content">A ContentManager</param>
        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[5];

            sprites[0] = content.Load<Texture2D>("Sprite\\hills_small");
            sprites[1] = content.Load<Texture2D>("Sprite\\Tours_Cathedral_facade");
            sprites[2] = content.Load<Texture2D>("Sprite\\dirt_tile1_background");
            sprites[3] = content.Load<Texture2D>("Sprite\\glorie2");
            sprites[4] = content.Load<Texture2D>("Sprite\\chair");
            
            //The choosen sprite
            this.Sprite = sprites[spriteID - 1];

            //
            if (spriteID == 2)
            {
                this.layer = 0.1f;
            }

            if (spriteID == 3)
            {
                this.layer = 0.92f;
            }

            backgroundMusic = content.Load<Song>("Midnight_Tale");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
        }

        public override void OnCollision(GameObject gameObject)
        {
            //Nothing is going to happens
        }

        public override void Update(GameTime gameTime)
        {
            //Nothing is going to happens
        }

        #endregion


    }
}

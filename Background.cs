using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Media;

namespace MortensKomeback
{
    internal class Background : GameObject
    {
        #region field
        private static Texture2D sprite1;
        private static Texture2D sprite2;
        private int spriteID; //Which sprite is going to be used
        private Song backgroundMusic;

        #endregion

        #region properties

        #endregion

        #region constructor
        public Background(int spriteID)
        {
            this.layer = 0f;
            this.scale = 1f;
            this.position.X = 1;
            this.position.Y = 1;
            this.health = 1;
            this.spriteID = spriteID;
        }

        #endregion

        #region method
        /// <summary>
        /// Loading background in to content
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            //Sprite = content.Load<Texture2D>("Sprite\\backgroundTEst");

            if (sprite1 == default)
            {
                sprite1 = content.Load<Texture2D>("Sprite\\backgroundTEst");
            }
            if (sprite2 == default)
            {
                sprite2 = content.Load<Texture2D>("Sprite\\Tours_Cathedral_facade");
            }
            

            if (spriteID == 1)
            {
                this.Sprite = sprite1;
            }
            if (spriteID == 2)
            {
                this.Sprite = sprite2;
                position.X = 200 * 150;
                position.Y = 88;
            }

            backgroundMusic = content.Load<Song>("Midnight_Tale");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
        }

        /// <summary>
        /// Tjecking if a gameobject is collidering but there is not anything going to happens to the Background
        /// </summary>
        /// <param name="gameObject">The gameobject it's collidering woth</param>
        public override void OnCollision(GameObject gameObject)
        {
            //Nothing is going to happens
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Nothing is going to happens
        }

        #endregion


    }
}

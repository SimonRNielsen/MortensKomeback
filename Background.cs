using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace MortensKomeback
{
    internal class Background : GameObject
    {
        #region field
        private static Texture2D sprite1;
        private static Texture2D sprite2;
        private static Texture2D sprite3;
        private static Texture2D sprite4;
        private static Texture2D sprite5;
        private int spriteID; //Which sprite is going to be used

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
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite1 = content.Load<Texture2D>("Sprite\\hills_small");
            sprite2 = content.Load<Texture2D>("Sprite\\Tours_Cathedral_facade");
            sprite3 = content.Load<Texture2D>("Sprite\\dirt_tile1_background");
            sprite4 = content.Load<Texture2D>("Sprite\\glorie2");
            sprite5 = content.Load<Texture2D>("Sprite\\chair");
            
            if (spriteID == 1)
            {
                this.Sprite = sprite1;
            }
            if (spriteID == 2)
            {
                this.Sprite = sprite2;
                this.layer = 0.01f;
            }
            if (spriteID == 3)
            {
                this.Sprite = sprite3;
                this.layer = 0.92f; //0.01 higher than PowerUp layer 
            }
            if (spriteID == 4)
            {
                this.Sprite = sprite4;
            }
            if (spriteID == 5)
            {
                this.Sprite = sprite5;
            }
            
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

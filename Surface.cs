﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Surface : GameObject
    {
        #region field
        private int spriteID; //Which sprite is going to be used
        private static Texture2D sprite1;
        private static Texture2D sprite2;
        #endregion

        #region properties
        public Rectangle LeftSideCollisionBox
        {
            get; private set;
        }

        public Rectangle RightSideCollisionBox
        {
            get; private set;
        }

        #endregion

        #region constructor
        public Surface(GraphicsDeviceManager graphics, Vector2 position, int spriteID)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
            this.layer = 0.1f;
            this.spriteID = spriteID;
            this.health = 1;
        }

        #endregion

        #region method

        public override void LoadContent(ContentManager content)
        {
            if(sprite1 == default)
            {
                sprite1 = content.Load<Texture2D>("Sprite\\dirt_tile1");
            }
            if(sprite2 == default)
            {
                sprite2 = content.Load<Texture2D>("Sprite\\grass_tile1");
            }
            if (spriteID == 1)
            {
                this.Sprite = sprite1;
            }
            if (spriteID == 2)
            {
                this.Sprite = sprite2;
            }
            LeftSideCollisionBox = new Rectangle((int)Position.X - ((Sprite.Width / 2) + 2), (int)Position.Y - (Sprite.Height / 2) + 10, 2, (Sprite.Height) - 20);
            RightSideCollisionBox = new Rectangle((int)Position.X + ((Sprite.Width / 2) + 2), (int)Position.Y - (Sprite.Height / 2) + 10, 2, (Sprite.Height) - 20);
           
        }


        public override void OnCollision(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// It's used to create a surface in Environment
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">Whice sprite is going to be showed</param>
        /// <returns></returns>
        public static Surface Create(GraphicsDeviceManager graphics, float x, float y, int spriteId)
        {
            return new Surface(graphics, new Vector2(x, y), spriteId);
        }


        #endregion
    }
}
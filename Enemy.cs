﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Enemy : Character
    {
        #region fields
        private bool flipped = false;
        private Vector2 direction;
        private Random rnd = new Random();
        private SpriteEffects spriteEffects;
        protected float distanceToPlayer;
        private Texture2D[] aggroSprite;
        private Texture2D[] normalSprites;

        private static Vector2 playerPosition;

        public static Vector2 PlayerPosition { get => playerPosition; set => playerPosition = value; }


        /// <summary>
        /// Calculates distances from enemy to player
        /// </summary>
        /// <param name="playerPosition"></param> current position of player
        /// <returns>the distance to player as a float</returns> 
        public float CalculateDistanceToPLayer(Vector2 playerPosition)
        {
            return Vector2.Distance(this.position, playerPosition);

        }

        #endregion


        /// <summary>
        /// enemy constructor
        /// </summary>
        public Enemy()
        {
            this.position.X = 2080;
            this.position.Y = 0;
            this.speed = 250;
            this.velocity = new Vector2(1, 0);
            this.fps = 15f;
            this.Health = 1;
            this.layer = 0.8f;
            this.scale = 1;
        }


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            //Loader sprites til animation
            sprites = new Texture2D[5];
            normalSprites = new Texture2D[5];
            for (int i = 0; i < sprites.Length; i++)
            {
                normalSprites[i] = content.Load<Texture2D>("gooseWalk" + i);
            }

            //Sætter default sprite
            sprites = normalSprites;
            sprite = sprites[0];
            ////Indlæs honk Lyd
            //honkSound = content.Load<SoundEffect>("gooseSound_cut");

            //loader aggro animation 
            aggroSprite = new Texture2D[7];
            for (int i = 0; i < aggroSprite.Length; i++)
            {
                aggroSprite[i] = content.Load<Texture2D>("aggro" + i);
            }

            //////////Sætter default sprite
            //////////sprite = aggroSprite[0];
        }

        public override void OnCollision(GameObject gameObject)
        {
            surfaceContact = false;

            if (gameObject is Surface)
            {
                surfaceContact = true;
                //honkSound.Play();
            }


        }

        public override void Update(GameTime gameTime)
        {
            

            //Fjende movement
           // Position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            #region flip enemy
            // Inverter sprite horisontalt, hvis fjenden ændrer retning
            if (velocity.X == 1)
            {
                spriteEffectIndex = 1;
            }
            else
            {
                spriteEffectIndex = 0;
            }

            distanceToPlayer = CalculateDistanceToPLayer(PlayerPosition);

            if (distanceToPlayer < 1500f)
            {
                speed = 500;
                sprite = aggroSprite[0];
                sprites = aggroSprite;
            }
            else
            {
                speed = 200;
                sprite = sprites[0];
                sprites = new Texture2D[normalSprites.Length];
                sprites = normalSprites;
            }

            velocity = new Vector2(velocity.X, 0); 
            
            base.Update(gameTime);

            Animate(gameTime);
            Move(gameTime);
            #endregion

            
        }

      
        #endregion
    }
}

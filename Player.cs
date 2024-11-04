using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Player : Character
    {
        #region Fields
        private Texture2D[] ammoSprites;
        private SoundEffect shootSound;
        private SoundEffect takeDamageSound;
        private bool canShoot = true;
        private bool canJump = true;

        #endregion

        #region Properties
        #endregion


        #region Constructor
        /// <summary>
        /// The constructor for the player
        /// </summary>
        public Player()
        {


        }


        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A method, that handles player input. WASD moves the player, and space makes it shoot. 
        /// </summary>
        private void HandeInput()
        {
            velocity = Vector2.Zero; //Resets the velocity, so move stops when no keys are pressed

            KeyboardState keyState = Keyboard.GetState();//Get the current keyboard state

            //If a is pressed
            if (keyState.IsKeyDown(Keys.A))
            {
                //Move left
                velocity += new Vector2(-1, 0);
            }
            //If d is pressed
            if (keyState.IsKeyDown(Keys.D))
            {
                //Move right
                velocity += new Vector2(+1, 0);
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            //If enter is pressed, the player will shoot
            if (keyState.IsKeyDown(Keys.Enter) && canShoot)
            {
                //Makes sure that you can only fire ones per space-click
                canShoot = false;
                Shoot();
            }
            if (keyState.IsKeyUp(Keys.Enter))
            {
                canShoot = true;
            }

            //If space is pressed, the player will jump.
            if (keyState.IsKeyDown(Keys.Space) && canJump)
            {
                canJump = false;
                Jump();
            }
            if (keyState.IsKeyUp(Keys.Space))
            {
                canJump = true;
            }

        }

        /// <summary>
        /// Shoots. 
        /// </summary>
        private void Shoot()
        {

        }
        /// <summary>
        /// Makes the player jump
        /// </summary>
        private void Jump()
        {
            velocity += new Vector2(0, +1);
        }

        #endregion

    }
}

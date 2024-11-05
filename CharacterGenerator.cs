using Microsoft.Xna.Framework;
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
    //TODO:
    // - Add text, and override draw
    // - Test with more sprites. 
    // 


    /// <summary>
    /// A class for the special GameObject CharacterGenerator. It is used, to make the player choose a sprite for the player
    /// character, and then to instantiate a player GameObject, with the chosen sprite. 
    /// </summary>
    internal class CharacterGenerator : GameObject
    {
        #region Fields
        private int spriteIndex = 0;

        #endregion

        #region Constructor
        public CharacterGenerator()
        {
            this.layer = 1;
            this.health = 1;
            this.origin = new Vector2(0, 0);
            this.scale = 1;
        }


        #endregion


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("morten_sprite");
            sprites = new Texture2D[1];
            sprites[0] = sprite;

        }

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
        }

        public override Draw()
        {

        }

        private void AddPlayer()
        {
            GameWorld.newGameObjects.Add(new Player(this.sprite));
        }

        private void HandleInput()
        {
            KeyboardState keyState = Keyboard.GetState();//Get the current keyboard state

            //If a is pressed
            if (keyState.IsKeyDown(Keys.A))
            {
                if (spriteIndex < sprites.Length - 1)
                {
                    spriteIndex++;
                    sprite = sprites[spriteIndex];
                }

            }
            //If d is pressed
            if (keyState.IsKeyDown(Keys.D))
            {
                if (spriteIndex > 0)
                {
                    spriteIndex--;
                    sprite = sprites[spriteIndex];
                }


            }

            //If enter is pressed, the player will shoot
            if (keyState.IsKeyDown(Keys.P))
            {
                    AddPlayer();
                    this.health = 0;
                
            }

        }

        #endregion
    }
}

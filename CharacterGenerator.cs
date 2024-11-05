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
        private SpriteFont standardFont;
        private string chosenMortenText;

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
            standardFont = content.Load<SpriteFont>("standardSpriteFont");
            sprites = new Texture2D[2];
            sprites[0] = content.Load<Texture2D>("morten_sprite");
            sprites[1] = content.Load<Texture2D>("morten_sprite2");
            sprite = sprites[0];

        }

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            SetChosenMortenText();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(standardFont, "Press a or d to choose between your Morten!", new Vector2(50, -250), Color.Yellow, 0f, Vector2.Zero,3, SpriteEffects.None, 0 );
            spriteBatch.DrawString(standardFont, "Press p when you are done creating your Morten, and want start the game", new Vector2(-100, -200), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(standardFont, chosenMortenText, new Vector2(-100, sprite.Height+15), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);

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
                   // SetChosenMortenText();
                }

            }
            //If d is pressed
            if (keyState.IsKeyDown(Keys.D))
            {
                if (spriteIndex > 0)
                {
                    spriteIndex--;
                    sprite = sprites[spriteIndex];
                    //SetChosenMortenText();
                }


            }

            //If enter is pressed, the player will shoot
            if (keyState.IsKeyDown(Keys.P))
            {
                    AddPlayer();
                    this.health = 0;
                
            }


        }
            private void SetChosenMortenText()
            {
            switch (spriteIndex)
            {
                case 0:
                    chosenMortenText = "Undercover Morten";
                    break;
                case 1:
                    chosenMortenText = "PURPLE! Undercover Morten";
                    break;
            }
            }

        #endregion
    }
}

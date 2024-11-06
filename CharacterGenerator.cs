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
        private Texture2D[,] mortenSprites = new Texture2D[3, 3];
        private Vector2 mortenIndex;
        private bool pressWASDAllowed = true;



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
            mortenSprites[0, 0] = content.Load<Texture2D>("morten_sprite");
            mortenSprites[0, 1] = content.Load<Texture2D>("morten_sprite2");
            mortenSprites[0, 2] = content.Load<Texture2D>("morten_sprite3");
            mortenSprites[1, 0] = content.Load<Texture2D>("morten_spritea");
            mortenSprites[1, 1] = content.Load<Texture2D>("morten_sprite2a");
            mortenSprites[1, 2] = content.Load<Texture2D>("morten_sprite3a");
            mortenSprites[2, 0] = content.Load<Texture2D>("morten_spriteb");
            mortenSprites[2, 1] = content.Load<Texture2D>("morten_sprite2b");
            mortenSprites[2, 2] = content.Load<Texture2D>("morten_sprite3b");

            sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];

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
            spriteBatch.DrawString(standardFont, "Press a or d to choose between your Morten!", new Vector2(50, -350), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(standardFont, "Press w or s to choosen between your weapon!", new Vector2(50, -300), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(standardFont, "Press p when you are done creating your Morten, and want to start the game", new Vector2(-100, -250), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(standardFont, chosenMortenText, new Vector2(-100, sprite.Height + 5), Color.Yellow, 0f, Vector2.Zero, 3, SpriteEffects.None, 0);
        }

        private void AddPlayer()
        {
            GameWorld.newGameObjects.Add(new Player(this.sprite));
        }

        private void HandleInput()
        {
            KeyboardState keyState = Keyboard.GetState();//Get the current keyboard state

            //If a is pressed
            if (keyState.IsKeyDown(Keys.A) && pressWASDAllowed)
            {
                pressWASDAllowed = false;

                if (mortenIndex.Y < mortenSprites.GetLength(1) - 1)
                {
                    mortenIndex.Y++;
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                }


            }
            //If d is pressed
            if (keyState.IsKeyDown(Keys.D) && pressWASDAllowed)
            {

                pressWASDAllowed = false;
                if (mortenIndex.Y > 0)
                {
                    mortenIndex.Y--;
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                }



            }
            //If w is pressed, genrator stage is switched so the player can choose weapon
            if (keyState.IsKeyDown(Keys.W) && pressWASDAllowed)
            {
                pressWASDAllowed = false;
                if (mortenIndex.X > 0)
                {
                    mortenIndex.X--;
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                }
            }
            //If s is pressed, generator stage is switched so the player can choose outfit
            if (keyState.IsKeyDown(Keys.S) && pressWASDAllowed)
            {
                pressWASDAllowed = false;
                if (mortenIndex.X < mortenSprites.GetLength(0) - 1)
                {
                    mortenIndex.X++;
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                }
            }

            //If P is pressed, the generator is done, and the player will spawn
            if (keyState.IsKeyDown(Keys.P))
            {

                AddPlayer();
                this.health = 0;

            }

            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D) && keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.S))
            {
                pressWASDAllowed = true;
            }

        }
        private void SetChosenMortenText()
        {
            switch (mortenIndex.Y)
            {
                case 0:
                    chosenMortenText = "Undercover Morten";
                    break;
                case 1:
                    chosenMortenText = "PURPLE! Undercover Morten";
                    break;
                case 2:
                    chosenMortenText = "Green! Undercover Morten";
                    break;
            }
        }

        #endregion
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    /// <summary>
    /// A class for the special GameObject CharacterGenerator. It is used, to make the player choose a sprite for the player
    /// character, and then to instantiate a Player GameObject, with the chosen sprite. 
    /// </summary>
    internal class CharacterGenerator : GameObject
    {
        #region Fields
        private int spriteIndex = 0;
        private int mortenSkinType;
        private SpriteFont standardFont;
        //A text that is drawn under the character to show which character is currently chosen. Set in SetChosenMortenText() method. 
        private string chosenMortenText;
        //Two dimensional array of sprites. Made so sprites on one axis have different outfits, and the other have different weapons. 
        //3 different outfits and 3 different weapons, gives an array with 9 possibilities.
        private Texture2D[,] mortenSprites = new Texture2D[2, 3];

        private Dictionary<string, Texture2D[]> loadedSprites = new Dictionary<string, Texture2D[]>();
        //A Vector2, that is used to choose sprites form the mortenSprites array. 
        private Vector2 mortenIndex;
        //Bool used to make sure that something only happens once per click on w,a,s or d. 
        private bool pressWASDAllowed = true;



        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the character generator. Should only be called at the start of the game. 
        /// </summary>
        public CharacterGenerator()
        {
            this.layer = .9f;
            this.health = 1;
            this.origin = new Vector2(0, 0);
            this.scale = 1;
        }


        #endregion


        #region Methods
        /// <summary>
        /// Loads all the sprites, that the player can choose from.
        /// </summary>
        /// <param name="content">The content manager, provided by MonoGame</param>
        public override void LoadContent(ContentManager content)
        {

            Texture2D[] munkeMortenSling = new Texture2D[4];
            munkeMortenSling[0] = content.Load<Texture2D>("munkeMortenSling0");
            munkeMortenSling[1] = content.Load<Texture2D>("munkeMortenSling1");
            munkeMortenSling[2] = content.Load<Texture2D>("munkeMortenSling2");
            munkeMortenSling[3] = content.Load<Texture2D>("munkeMortenSling3");
            loadedSprites.Add("munkeMortenSling0", munkeMortenSling);

            Texture2D[] munkeMortenSlingGul = new Texture2D[4];
            munkeMortenSling[0] = content.Load<Texture2D>("munkeMortenSlingGul0");
            munkeMortenSling[1] = content.Load<Texture2D>("munkeMortenSlingGul1");
            munkeMortenSling[2] = content.Load<Texture2D>("munkeMortenSlingGul2");
            munkeMortenSling[3] = content.Load<Texture2D>("munkeMortenSlingGul3");
            loadedSprites.Add("munkeMortenSlingGul0", munkeMortenSling);

            Texture2D[] underCoverMortenSling = new Texture2D[4];
            underCoverMortenSling[0] = content.Load<Texture2D>("underCoverMortenSling0");
            underCoverMortenSling[1] = content.Load<Texture2D>("underCoverMortenSling1");
            underCoverMortenSling[2] = content.Load<Texture2D>("underCoverMortenSling2");
            underCoverMortenSling[3] = content.Load<Texture2D>("underCoverMortenSling3");
            loadedSprites.Add("underCoverMortenSling0", underCoverMortenSling);

            Texture2D[] underCoverMortenSlingGul = new Texture2D[4];
            underCoverMortenSling[0] = content.Load<Texture2D>("underCoverMortenSlingGul0");
            underCoverMortenSling[1] = content.Load<Texture2D>("underCoverMortenSlingGul1");
            underCoverMortenSling[2] = content.Load<Texture2D>("underCoverMortenSlingGul2");
            underCoverMortenSling[3] = content.Load<Texture2D>("underCoverMortenSlingGul3");
            loadedSprites.Add("underCoverMortenSlingGul0", underCoverMortenSling);

            Texture2D[] munkeMortenHvid0 = new Texture2D[4];
            underCoverMortenSling[0] = content.Load<Texture2D>("munkeMortenHvid0");
            underCoverMortenSling[1] = content.Load<Texture2D>("munkeMortenHvid1");
            underCoverMortenSling[2] = content.Load<Texture2D>("munkeMortenHvid2");
            underCoverMortenSling[3] = content.Load<Texture2D>("munkeMortenHvid3");
            loadedSprites.Add("munkeMortenHvid0", munkeMortenHvid0);

            Texture2D[] munkeMortenHvidSlingGul0 = new Texture2D[4];
            underCoverMortenSling[0] = content.Load<Texture2D>("munkeMortenHvidSlingGul0");
            underCoverMortenSling[1] = content.Load<Texture2D>("munkeMortenHvidSlingGul1");
            underCoverMortenSling[2] = content.Load<Texture2D>("munkeMortenHvidSlingGul2");
            underCoverMortenSling[3] = content.Load<Texture2D>("munkeMortenHvidSlingGul3");
            loadedSprites.Add("munkeMortenHvidSlingGul0", munkeMortenHvidSlingGul0);

            standardFont = content.Load<SpriteFont>("standardSpriteFont");
            mortenSprites[0, 0] = content.Load<Texture2D>("munkeMortenSling0");
            mortenSprites[0, 1] = content.Load<Texture2D>("underCoverMortenSling0");
            mortenSprites[1, 0] = content.Load<Texture2D>("munkeMortenSlingGul0");
            mortenSprites[1, 1] = content.Load<Texture2D>("underCoverMortenSlingGul0");
            mortenSprites[0, 2] = content.Load<Texture2D>("munkeMortenHvid0");
            mortenSprites[1, 2] = content.Load<Texture2D>("munkeMortenHvidSlingGul0");
            /*mortenSprites[2, 0] = content.Load<Texture2D>("morten_spriteb");
            mortenSprites[2, 1] = content.Load<Texture2D>("morten_sprite2b");
            mortenSprites[2, 2] = content.Load<Texture2D>("morten_sprite3b");*/

            sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
            
        }

        /// <summary>
        /// OnCollision for CharacterGenerator, should not have any functionality. It is just a result of the method being abstract 
        /// and inherited from GameObject.
        /// </summary>
        /// <param name="gameObject"></param>
        public override void OnCollision(GameObject gameObject)
        {

        }

        /// <summary>
        /// Update function that continually is called, as long as the CharacterGenerator is in GameWorlds gameObjects list.
        /// </summary>
        /// <param name="gameTime">GameTime, given by GameWorld</param>
        public override void Update(GameTime gameTime)
        {
            GameWorld.Camera.Position = this.Position;

            HandleInput();
            SetChosenMortenText();
        }

        /// <summary>
        /// Draw function, that draws the sprite, as is standard in GameObjects draw function.
        /// Also draws the text for the character generator with isntructions, and the description of the chosen sprite.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch from GameWorld.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(standardFont, "Press A or D to choose between your Morten!", new Vector2(-420, -350), Color.Black, 0f, Vector2.Zero, 3, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(standardFont, "Press W or S to choose between your weapon!", new Vector2(-420, -300), Color.Black, 0f, Vector2.Zero, 3, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(standardFont, "Press P when you want to start the game", new Vector2(-420, -250), Color.Black, 0f, Vector2.Zero, 3, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(standardFont, chosenMortenText, new Vector2(-chosenMortenText.Length * 12, sprite.Height / 2 + 10), Color.Black, 0f, Vector2.Zero, 3, SpriteEffects.None, 0.9f);
        }

        /// <summary>
        /// This function adds a player to the game, by adding it to newGameObjects list. The player constructor called 
        /// is automatically given the chosen sprite as an argument.
        /// </summary>
        private void AddPlayer()
        {
            sprites = loadedSprites[this.sprite.Name];
            GameWorld.newGameObjects.Add(new Player(this.sprite, sprites, mortenSkinType));
        }
        /// <summary>
        /// Handles the input from the player. 
        /// W and S chooses weapon. A and D chooses outfit. P starts the game by calling AddPLayer() and deletes the CharacterGenerator instance.
        /// </summary>
        private void HandleInput()
        {
            KeyboardState keyState = Keyboard.GetState();//Get the current keyboard state

            //If a is pressed the current sprite  is changed. Only changes between the places in the twodimensional mortneSprites array, where the outfit is different
            if (keyState.IsKeyDown(Keys.A) && pressWASDAllowed)
            {
                pressWASDAllowed = false;
               
                    mortenIndex.Y--;
                if (mortenIndex.Y <0 )
                {
                    mortenIndex.Y = (mortenSprites.GetLength(1) - 1);
                }
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                
            }
            //If d is pressed the current sprite is changed.Only changes between the places in the twodimensional mortneSprites array, where the outfit is different
            if (keyState.IsKeyDown(Keys.D) && pressWASDAllowed)
            {
                pressWASDAllowed = false;
                    mortenIndex.Y++;
                if (mortenIndex.Y > mortenSprites.GetLength(1) - 1)
                {
                    mortenIndex.Y = 0;
                }
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                
            }

            //If w is pressed, the current sprite is changed. Only changes between the places in the twodimensional mortneSprites array, where the weapon is different
            if (keyState.IsKeyDown(Keys.W) && pressWASDAllowed)
            {
                pressWASDAllowed = false;

                mortenIndex.X--;
                if (mortenIndex.X < 0)
                {
                    mortenIndex.X = (mortenSprites.GetLength(0) - 1);
                }
                    sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                
            }
            //If w is pressed, the current sprite is changed. Only changes between the places in the twodimensional mortneSprites array, where the weapon is different
            if (keyState.IsKeyDown(Keys.S) && pressWASDAllowed)
            {
                pressWASDAllowed = false;
                
                    mortenIndex.X++;
                if (mortenIndex.X > mortenSprites.GetLength(0) - 1)
                {
                    mortenIndex.X = 0;
                }
                sprite = mortenSprites[(int)mortenIndex.X, (int)mortenIndex.Y];
                    // SetChosenMortenText();
                
            }

            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D) && keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.S))
            {
                pressWASDAllowed = true;
            }

            //If P is pressed, the generator is done, and the player will spawn 
            if (keyState.IsKeyDown(Keys.P))
            {

                AddPlayer();
                //Sets the health to 0, so the Update() in GameWorld, will delete it. 
                this.health = 0;

            }


        }
        /// <summary>
        /// Sets the the text shown under the sprite, informing the player about the current sprite chosen. 
        /// Changes depending on the outfit of the player ie. what the current Y value in mortenIndex is. 
        /// </summary>
        private void SetChosenMortenText()
        {
            switch (mortenIndex.Y)
            {
                case 0:
                    chosenMortenText = "Munke Morten";
                    mortenSkinType = 1;
                    break;
                case 1:
                    chosenMortenText = "Undercover Morten";
                    mortenSkinType = 1;
                    break;
                case 2:
                    chosenMortenText = "Hellig Morten";
                    mortenSkinType = 1;
                    break;
            }
        }

        

        #endregion
    }
}

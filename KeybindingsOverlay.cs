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
    /// <summary>
    /// A class for an overlay players can choose to see on the screen, with a guide for the game's keybindings
    /// </summary>
    internal class KeybindingsOverlay : GameObject
    {
        #region Fields
        private SpriteFont standardFont;
        private bool showKeyBindings = false;
        private bool pressHAllowed = true;

        #endregion
        /// <summary>
        /// Constructor for the KeybindingsOverlay. Should be used when the game is initialised. 
        /// Sets the essentiel attributes for the KeybindinOverlay to be shown properly. 
        /// </summary>
        #region Constructor
        public KeybindingsOverlay()
        {
            this.health = 1;
            this.position = new Vector2(960, -540);
            this.scale = 1;
            this.layer = 0.9f;
        }
        #endregion

        #region Methods

        public override void LoadContent(ContentManager content)
        {
            standardFont = content.Load<SpriteFont>("standardSpriteFont");
        }

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            this.position.X = GameWorld.Camera.Position.X + (600 / GameWorld.Camera.Zoom);
            this.position.Y = GameWorld.Camera.Position.Y - (500 / GameWorld.Camera.Zoom);

        }
        /// <summary>
        /// Overrides GameObjects draw method, to draw text that describes the games keybindings
        /// </summary>
        /// <param name="spriteBatch">Spritebatch form GameWorld</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (showKeyBindings)
            {
                spriteBatch.DrawString(standardFont, "Move: Press A or D", position, Color.Black, 0f, origin, 3, SpriteEffects.None, layer);
                spriteBatch.DrawString(standardFont, "Jump: Press SPACE", new Vector2(position.X, position.Y+50), Color.Black, 0f, origin, 3, SpriteEffects.None, layer);
                spriteBatch.DrawString(standardFont, "Shoot: Press ENTER", new Vector2(position.X, position.Y + 100), Color.Black, 0f, origin, 3, SpriteEffects.None, layer);
                spriteBatch.DrawString(standardFont, "Hide keybinds: press H", new Vector2(position.X, position.Y + 150), Color.Black, 0f, origin, 3, SpriteEffects.None, layer);
            }
            else
            {
                spriteBatch.DrawString(standardFont, "Show keybinds: press H", position, Color.Black, 0f, origin, 3, SpriteEffects.None, layer);
            }
        }
        /// <summary>
        /// Handles input form the player, to toggle if the keybindins should be shown or not. 
        /// </summary>
        private void HandleInput()
        {
            KeyboardState keyState = Keyboard.GetState()
                ;//Get the current keyboard state

            if (keyState.IsKeyDown(Keys.H) && pressHAllowed)
            {
                switch (showKeyBindings)
                {
                    case true:
                        showKeyBindings = false;
                        break;
                    case false:
                        showKeyBindings = true;
                        break;
                }

                pressHAllowed = false;
            }

            if (keyState.IsKeyUp(Keys.H))
            {
                pressHAllowed = true;
            }


        }

        #endregion
    }
}

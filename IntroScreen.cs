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
    internal class IntroScreen : GameObject
    {
        private Texture2D buttonSprite;
        private SpriteFont spriteFont;
        private Color playButtonColor = Color.DarkRed;
        private Color exitButtonColor = Color.DarkRed;

        public IntroScreen(Vector2 placement)
        {
            this.position = placement;
            this.health = 9999;
            this.layer = 0.99f;
            this.scale = 1.7f;
        }


        public override void LoadContent(ContentManager content)
        {
            this.sprite = content.Load<Texture2D>("udkast");
            spriteFont = content.Load<SpriteFont>("mortalKombatFont");
            buttonSprite = content.Load<Texture2D>("button");
            GameWorld.newGameObjects.Add(new Button(buttonSprite, new Vector2(-700, 300)));
            GameWorld.newGameObjects.Add(new Button(buttonSprite, new Vector2(700, 300)));
        }

        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput(GameWorld.mousePosition, GameWorld.leftMouseButtonClick);
        }

        private void HandleInput(Vector2 pos, bool click)
        {

            //Play button
            if (pos.X < 580 && pos.X > 500 && pos.Y < 740 && pos.Y > 700 && click)
            {
                GameWorld.removeIntro = true;

            }
            else if (pos.X < 580 && pos.X > 500 && pos.Y < 740 && pos.Y > 700)
            {
                playButtonColor = Color.Yellow;
            }
            else
            {
                playButtonColor = Color.DarkRed;
            }

            //Exit button
            if (pos.X < 1420 && pos.X > 1340 && pos.Y < 740 && pos.Y > 700 && click)
            {
                GameWorld.exitGame = true;
            }
            else if (pos.X < 1420 && pos.X > 1340 && pos.Y < 740 && pos.Y > 700)
            {
                exitButtonColor = Color.Yellow;
            }
            else
            {
                exitButtonColor = Color.DarkRed;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, SpriteEffects.None, layer);
            spriteBatch.DrawString(spriteFont, "Play", new Vector2(-700, 300), playButtonColor, 0f, new Vector2(18, 8), 2f, SpriteEffects.None, 0.999f);
            spriteBatch.DrawString(spriteFont, "Exit", new Vector2(700, 300), exitButtonColor, 0f, new Vector2(16, 8), 2f, SpriteEffects.None, 0.999f);
        }

    }
}
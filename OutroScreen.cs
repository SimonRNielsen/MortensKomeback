using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class OutroScreen : GameObject
    {
        private Texture2D buttonSprite;
        private SpriteFont spriteFont;
        public OutroScreen(Vector2 placement)
        {
            this.position = placement;
            this.health = 9999;
            this.layer = 0.99f;
            this.scale = 1.7f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[2];
            sprites[0] = content.Load<Texture2D>("udkast"); //Loss
            sprites[1] = content.Load<Texture2D>("udkast"); //Win

            if (GameWorld.win == true)
            {
                GameWorld.win = false;
                this.sprite = sprites[1];
            }
            else
                this.sprite = sprites[0];

            spriteFont = content.Load<SpriteFont>("mortalKombatFont");
            buttonSprite = content.Load<Texture2D>("button");
        }

        public override void OnCollision(GameObject gameObject)
        {
            //
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameWorld.spawnOutro)
            {
                GameWorld.newGameObjects.Add(new ExitButton(buttonSprite, new Vector2(position.X + 300, position.Y + 300), spriteFont));
                GameWorld.newGameObjects.Add(new RestartButton(buttonSprite, new Vector2(position.X - 300, position.Y + 300), spriteFont));
            }
            GameWorld.spawnOutro = true;

        }
    }
}

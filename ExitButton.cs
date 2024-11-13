using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MortensKomeback
{
    internal class ExitButton : Button
    {

        public ExitButton(Texture2D sprite, Vector2 pos, SpriteFont font)
        {
            this.sprite = sprite;
            this.position = pos;
            this.health = 9999;
            this.layer = 0.998f;
            spriteFont = font;
            this.buttonText = "Exit";
        }

        

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is MousePointer)
                collision = true;
            if (gameObject is MousePointer && GameWorld.leftMouseButtonClick == true)
                GameWorld.exitGame = true;
        }

    }
}

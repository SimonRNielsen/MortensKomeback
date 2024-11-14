using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class RestartButton : Button
    {
        public RestartButton(Texture2D sprite, Vector2 pos, SpriteFont font)
        {
            this.sprite = sprite;
            this.position = pos;
            this.health = 9999;
            this.layer = 0.998f;
            spriteFont = font;
            this.buttonText = "Restart";
            this.textXDisplacement = -25f;
        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is MousePointer)
                collision = true;
            if (gameObject is MousePointer && GameWorld.leftMouseButtonClick == true)
                GameWorld.restart = true;
        }
    }
}

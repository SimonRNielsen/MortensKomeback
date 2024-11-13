﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MortensKomeback
{
    internal class PlayButton : Button
    {

        public PlayButton(Texture2D sprite, Vector2 pos, SpriteFont font)
        {
            this.sprite = sprite;
            this.position = pos;
            this.health = 9999;
            this.layer = 0.998f;
            spriteFont = font;
            this.buttonText = "Play";
        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is MousePointer)
                collision = true;
            if (gameObject is MousePointer && GameWorld.leftMouseButtonClick == true)
                GameWorld.removeScreen = true;
        }

    }
}
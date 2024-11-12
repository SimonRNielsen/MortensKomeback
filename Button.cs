using Microsoft.Xna.Framework;

namespace MortensKomeback
{
    public abstract class Button : GameObject
    {
        protected Color[] buttonColor = new Color[2] {Color.DarkRed, Color.Yellow};
        protected int colorIndex;
    }
}

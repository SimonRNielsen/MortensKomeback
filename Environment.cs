
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MortensKomeback
{
    public class Environment
    {
        //Environment is the layout for the level and not a GameObject 
        #region field
        private GraphicsDeviceManager _graphics;

        private List<GameObject> surfaces = new List<GameObject>();

        private int tileHeight = 195;
        private int tileWidth = 206 - 1;


        #endregion

        #region properties
        public List<GameObject> Surfaces { get => surfaces; set => surfaces = value; }

        #endregion

        #region constructor

        public Environment(GraphicsDeviceManager graphics)
        {
            surfaces.Add(new Background(_graphics));

            for (int i = 0; i < 66; i++)
            {
            AddSurface((tileWidth * i), graphics.PreferredBackBufferHeight, 2);
            }
        }
        #endregion

        #region method

        private void AddSurface(float x, float y, int spriteId)
        {
            surfaces.Add(Surface.Create(_graphics, x, y, spriteId));
        }

        private void AddAvSurface(float x, float y, int spriteId)
        {
            surfaces.Add(AvSurface.Create(_graphics, x, y));
        }

        //private void AddSurfaces(float x, float y, int spriteId, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        AddSurface(x * i, y, spriteId);
        //    }
        //}

        #endregion
    }

}


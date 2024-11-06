﻿
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


        #endregion

        #region properties
        public List<GameObject> Surfaces { get => surfaces; set => surfaces = value; }

        #endregion

        #region constructor

        public Environment(GraphicsDeviceManager graphics)
        {
            surfaces.Add(new Background(_graphics));
            //AddSurface(200f, 400f, 2);
            //AddSurface(400f, 400f, 4);
            //tiles.Add(new Surface(graphics, new Vector2(400f, 200f), 2));

            AddSurfaces(200f, 400f, 2, 5);

            AddSurface(600f, 300f, 2);
        }
        #endregion

        #region method

        private void AddSurface(float x, float y, int spriteId)
        {
            surfaces.Add(Surface.Create(_graphics, x, y, spriteId));
        }

        private void AddSurfaces(float x, float y, int spriteId, int times)
        {
            for (int i = 0; i < times; i++)
            {
                AddSurface(x * i, y, spriteId);
            }
        }

        #endregion
    }

}


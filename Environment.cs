using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    public class Environment
    {
        //Environment is the layout for the level and not a GameObject 
        #region field
        private GraphicsDeviceManager _graphics;
        private List<GameObject> surfaces = new List<GameObject>();

        /// <summary>
        /// The Environment is build up of the tile/sprites "dirt_tile1" and "grass_tile1" which the size is 200x200 pixel. 
        /// For the tiles is overlapping they are placed 1 over eachother
        /// </summary>
        private int tileSize = 199;


        #endregion

        #region properties
        public List<GameObject> Surfaces { get => surfaces; set => surfaces = value; }

        #endregion

        #region constructor
        /// <summary>
        /// Construction the Environment of all the surfaces and backgroud
        /// </summary>
        /// <param name="graphics"></param>
        public Environment(GraphicsDeviceManager graphics)
        {
            int graphicsHeight = graphics.PreferredBackBufferHeight;

            //
            int grass = 1;
            int dirt = 2;
            int cloud5 = 3;
            int cloud3 = 4;


            #region button
            //First buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize ,  dirt, 1, 31); // Græstop på jorden (Morten spawner på den rigtige overflade)
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), grass, 1, 31); // Jordbund

            //Second buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  dirt, 34, 49);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), grass, 34, 49);

            //Third buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  dirt, 52, 91);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), grass, 52, 91);

            //Forth buttom
            for (int i = -1; i < 3; i++)
            {
                AddSurfaces(tileSize, graphicsHeight + (tileSize * i), grass, 109, 110);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  dirt, 109, 110);

            //Fifth buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  dirt, 124, 180);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), grass, 124, 180);
            AddSurfaces(tileSize, graphicsHeight + tileSize, grass, 181, 182);
            #endregion

            #region hill
            //First hill
            AddSurfaces((tileSize), graphicsHeight,  dirt, 13, 14);
            AddSurfaces((tileSize), graphicsHeight, grass, 15, 17);
            AddSurfaces((tileSize), graphicsHeight - tileSize,  dirt, 15, 17);

            //Secong hill
            AddSurface(tileSize * 86, graphicsHeight, grass);
            AddSurfaces(tileSize, graphicsHeight, grass, 88, 91);
            AddSurface(tileSize * 87, graphicsHeight - tileSize, grass);
            AddSurfaces(tileSize, graphicsHeight - tileSize, grass, 89, 91);
            AddSurface(tileSize * 88, graphicsHeight - (tileSize * 2), grass);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2), grass, 90, 91);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  dirt, 90, 92);

            //Third hill
            AddSurfaces(tileSize, graphicsHeight, grass, 124, 128); //
            for (int i = 1; i < 5; i++)
            {
                AddSurface(tileSize * 127, graphicsHeight - (tileSize * i), dirt);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5), grass, 125, 127);
            AddSurface(tileSize * 127, graphicsHeight - (tileSize * 5), grass);
            AddSurface(tileSize * 123, graphicsHeight - (tileSize * 6), grass);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6), grass, 125, 127);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 7),  dirt, 125, 127);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  dirt, 131, 133);

            #endregion

            #region stairs
            //First stairs
            AddSurfaces((tileSize), graphicsHeight,  dirt, 26, 27);
            AddSurfaces((tileSize), graphicsHeight, grass, 28, 29);
            AddSurfaces((tileSize), graphicsHeight - tileSize,  dirt, 28, 28);
            AddSurfaces((tileSize), graphicsHeight - tileSize, grass, 29, 29);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 2),  dirt, 29, 29);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 2), grass, 30, 30);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 3),  dirt, 30, 31);
            AddSurface(tileSize * 33, graphicsHeight - (tileSize * 5), cloud3);

            AddSurface((tileSize * 35), graphicsHeight - (tileSize * 6), grass); 
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 7),  dirt, 39, 41);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 9),  dirt, 36, 38);

            //Second stairs
            AddSurfaces(tileSize, graphicsHeight,  dirt, 60 ,66);
            AddSurfaces(tileSize, graphicsHeight, grass, 67, 70);
            AddSurfaces(tileSize, graphicsHeight - tileSize,  dirt, 67, 69);
            AddSurface(tileSize * 69, graphicsHeight - tileSize, dirt);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  dirt, 70, 71);

            AddSurface(tileSize * 73, graphicsHeight - (tileSize * 3), grass);

            AddSurface(tileSize * 76, graphicsHeight - (tileSize * 5), cloud3);
            AddSurface(tileSize * 79, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 82, graphicsHeight - (tileSize * 7), dirt);

            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  dirt, 84, 85);

            AddSurface(tileSize * 84, graphicsHeight - (tileSize * 9), cloud3);
            for (int i = 0; i < 12; i++)
            {
                AddSurface(tileSize * (87 + i * 3), graphicsHeight - (tileSize * 9), cloud5);
            }

            #endregion

            #region platform
            //First platform
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10),  dirt, 26, 27);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10), grass, 28, 31);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10),  dirt, 32, 33);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 11),  dirt, 28, 31);

            //Second platform
            AddSurface(tileSize * 54, graphicsHeight - (tileSize * 5), cloud5);

            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5), grass, 59, 66);
            AddSurface(tileSize * 66, graphicsHeight - (tileSize * 5), grass);
            AddSurface(tileSize * 58, graphicsHeight - (tileSize * 6), grass);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 65, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 7), grass);
            AddSurface(tileSize * 65, graphicsHeight - (tileSize * 7), grass);

            //Third platforms
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  dirt, 95, 99);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  dirt, 102, 103);
            AddSurface(tileSize * 105, graphicsHeight - tileSize, grass);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (111 + i * 3), graphicsHeight - tileSize, grass);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 4),  dirt, 113, 114);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5),  dirt, 116, 117);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6),  dirt, 120, 121);


            #endregion

            #region pillar
            //1
            AddSurface(tileSize * 40, graphicsHeight, dirt);
            AddSurface(tileSize * 40, graphicsHeight - tileSize, grass);

            //2
            AddSurface(tileSize * 44, graphicsHeight - (tileSize * 2), dirt);
            AddSurface(tileSize * 44, graphicsHeight - (tileSize * 3), grass);

            //3
            for (int i = 0; i < 4; i++)
            {
                AddSurface(tileSize * 48, graphicsHeight - (tileSize * i), dirt);
            }
            AddSurface(tileSize * 48, graphicsHeight - (tileSize * 4), grass);

            //4
            AddSurfaces(tileSize, graphicsHeight, grass, 52, 53);
            AddSurface(tileSize * 51, graphicsHeight - tileSize, dirt);
            AddSurface(tileSize * 52, graphicsHeight - tileSize, grass);
            AddSurface(tileSize * 51, graphicsHeight - (tileSize * 2), grass);
            #endregion

            #region obstacles
           
            #endregion

            #region stairways to heaven
            int shorter = 45;
            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (225 + i - shorter), graphicsHeight - (tileSize * i), 2);
                AddSurfaces(tileSize, graphicsHeight - (tileSize * i), grass, 227 + i - shorter, 229 + i - shorter);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5),  dirt, 231 - shorter, 232 - shorter);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6),  dirt, 233 - shorter, 237 - shorter);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (237 + i - shorter), graphicsHeight - (tileSize * (i + 6)), grass);
                AddSurfaces(tileSize, graphicsHeight - (tileSize * (i + 6)), grass, 239 + i - shorter, 241 + i - shorter);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 11),  dirt, 198, 200);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 12),  dirt, 201, 203);

            #endregion

            #region AvSurface
            AddAvSurface(tileSize * 30, graphicsHeight + (tileSize * 1.5f));
            AddAvSurface(tileSize * 47, graphicsHeight + (tileSize * 1.5f));
            AddAvSurface(tileSize * 99, graphicsHeight + (tileSize * 1.5f));
            AddAvSurface(tileSize * 115, graphicsHeight + (tileSize * 1.5f));


            #endregion
        }
        #endregion

        #region method
        /// <summary>
        /// Adding one Surface
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">The sprite of the Surface</param>
        private void AddSurface(float x, float y, int spriteId)
        {
            surfaces.Add(Surface.Create(_graphics, x, y, spriteId));
        }

        /// <summary>
        /// Adding multipel Surfac
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">The sprite of the Surface</param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex">The number of time the Surface is added</param>
        private void AddSurfaces(float x, float y, int spriteId, int startIndex, int endIndex) /// Lav ændring
        {
            for (int i = startIndex-1; i < endIndex; i++)
            {
                AddSurface(x * i, y, spriteId);
            }
        }

        /// <summary>
        /// Adding one AvSurface
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        private void AddAvSurface(float x, float y)
        {
            surfaces.Add(AvSurface.Create(_graphics, x, y));
        }
        #endregion
    }

}


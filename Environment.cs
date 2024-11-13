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

            //The following ints is refurring to the differents sprites 
            int dirt = 1;  //"dirt_tile1"
            int grass = 2; //"grass_tile1"
            int cloud5 = 3; //"cloud5"
            int cloud3 = 4; //"cloud3"
            int trans = 5; //"transparentTile"

            #region bakcground
            surfaces.Add(new Background(2, 200 * 150, 88));

            int hillSize = 3586;
            for (int i = 0; i < 10; i++)
            {
            surfaces.Add(new Background(1, (hillSize - tileSize)/ 2 + hillSize * i, 1100));
            }

            //Hidden rum
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    surfaces.Add(new Background(3, tileSize * (124 + i), graphicsHeight - (tileSize * (1 + j))));
                }
            }

            //Second platform
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    surfaces.Add(new Background(3, tileSize * (60 + i), graphicsHeight - (tileSize * (6 + j))));
                }
            }

            #endregion

            #region button
            //First buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize ,  grass, 1, 31); 
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), dirt, 1, 31); 

            //Second buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  grass, 34, 49);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), dirt, 34, 49);

            //Third buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  grass, 52, 91);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), dirt, 52, 91);

            //Forth buttom
            for (int i = -1; i < 3; i++)
            {
                AddSurfaces(tileSize, graphicsHeight + (tileSize * i), dirt, 109, 110);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  grass, 109, 110);

            //Fifth buttom
            AddSurfaces((tileSize), graphicsHeight + tileSize,  grass, 124, 180);
            AddSurfaces((tileSize), graphicsHeight + (tileSize * 2), dirt, 124, 181);
            AddSurfaces(tileSize, graphicsHeight + tileSize, dirt, 181, 182);
            #endregion

            #region hill
            //First hill
            AddSurfaces((tileSize), graphicsHeight,  grass, 13, 14);
            AddSurfaces((tileSize), graphicsHeight, dirt, 15, 17);
            AddSurfaces((tileSize), graphicsHeight - tileSize,  grass, 15, 17);

            //Secong hill
            AddSurface(tileSize * 86, graphicsHeight, grass);
            AddSurfaces(tileSize, graphicsHeight, dirt, 88, 91);
            AddSurface(tileSize * 87, graphicsHeight - tileSize, grass);
            AddSurfaces(tileSize, graphicsHeight - tileSize, dirt, 89, 91);
            AddSurface(tileSize * 88, graphicsHeight - (tileSize * 2), grass);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2), dirt, 90, 91);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  grass, 90, 92);

            //Third hill
            AddSurfaces(tileSize, graphicsHeight, dirt, 124, 128); //
            for (int i = 1; i < 5; i++)
            {
                AddSurface(tileSize * 127, graphicsHeight - (tileSize * i), dirt);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5), dirt, 125, 127);
            AddSurface(tileSize * 127, graphicsHeight - (tileSize * 5), grass);
            AddSurface(tileSize * 123, graphicsHeight - (tileSize * 6), grass);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6), dirt, 125, 127);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 7),  grass, 125, 127);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  grass, 131, 133);

            #endregion

            #region stairs
            //First stairs
            AddSurfaces((tileSize), graphicsHeight,  grass, 26, 27);
            AddSurfaces((tileSize), graphicsHeight, dirt, 28, 29);
            AddSurfaces((tileSize), graphicsHeight - tileSize,  grass, 28, 28);
            AddSurfaces((tileSize), graphicsHeight - tileSize, dirt, 29, 29);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 2),  grass, 29, 29);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 2), dirt, 30, 30);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 3),  grass, 30, 31);
            AddSurface(tileSize * 33, graphicsHeight - (tileSize * 5), cloud3);

            AddSurface((tileSize * 35), graphicsHeight - (tileSize * 6), cloud5); 
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 7),  grass, 39, 41);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 9),  grass, 36, 38);

            //Second stairs
            AddSurfaces(tileSize, graphicsHeight,  grass, 60 ,66);
            AddSurfaces(tileSize, graphicsHeight, dirt, 67, 70);
            AddSurfaces(tileSize, graphicsHeight - tileSize,  grass, 67, 69);
            AddSurface(tileSize * 69, graphicsHeight - tileSize, dirt);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  grass, 70, 71);

            AddSurface(tileSize * 73, graphicsHeight - (tileSize * 3), cloud5);

            AddSurface(tileSize * 76, graphicsHeight - (tileSize * 5), cloud3);
            AddSurface(tileSize * 79, graphicsHeight - (tileSize * 6), grass);
            AddSurface(tileSize * 82, graphicsHeight - (tileSize * 7), grass);

            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  grass, 84, 85);

            AddSurface(tileSize * 84, graphicsHeight - (tileSize * 9), cloud3);
            for (int i = 0; i < 12; i++)
            {
                AddSurface(tileSize * (87 + i * 3), graphicsHeight - (tileSize * 9), cloud5);
            }

            #endregion

            #region platform
            //First platform
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10),  grass, 26, 27);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10), dirt, 28, 31);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 10),  grass, 32, 33);
            AddSurfaces((tileSize), graphicsHeight - (tileSize * 11),  grass, 28, 31);

            //Second platform
            AddSurface(tileSize * 54, graphicsHeight - (tileSize * 5), cloud5);

            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5), dirt, 59, 66);
            AddSurface(tileSize * 66, graphicsHeight - (tileSize * 5), grass);
            AddSurface(tileSize * 58, graphicsHeight - (tileSize * 6), grass);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 65, graphicsHeight - (tileSize * 6), dirt);
            AddSurface(tileSize * 59, graphicsHeight - (tileSize * 7), grass);
            AddSurface(tileSize * 65, graphicsHeight - (tileSize * 7), grass);

            //Third platforms
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 3),  grass, 95, 99);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 2),  grass, 102, 103);
            AddSurface(tileSize * 105, graphicsHeight - tileSize, grass);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (111 + i * 3), graphicsHeight - tileSize, grass);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 4),  grass, 113, 114);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5),  grass, 116, 117);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6),  grass, 120, 121);


            #endregion

            #region pillar
            //1
            AddSurface(tileSize * 40, graphicsHeight, dirt);
            AddSurface(tileSize * 40, graphicsHeight - tileSize, grass);

            //2
            AddSurface(tileSize * 44, graphicsHeight - (tileSize * 2), dirt);
            AddSurface(tileSize * 44, graphicsHeight - (tileSize * 3), grass);
            AddSurface(tileSize * 43, graphicsHeight - (tileSize * 2), grass);


            //3
            for (int i = 0; i < 4; i++)
            {
                AddSurface(tileSize * 48, graphicsHeight - (tileSize * i), dirt);
            }
            AddSurface(tileSize * 48, graphicsHeight - (tileSize * 4), grass);

            //4
            AddSurfaces(tileSize, graphicsHeight, dirt, 52, 53);
            AddSurface(tileSize * 51, graphicsHeight - tileSize, dirt);
            AddSurface(tileSize * 52, graphicsHeight - tileSize, grass);
            AddSurface(tileSize * 51, graphicsHeight - (tileSize * 2), grass);
            #endregion

            #region clouds
            //Different clouds around the map
            AddSurface(tileSize * 35, graphicsHeight - (tileSize * 2), cloud5); //1
            AddSurface(tileSize * 39f, graphicsHeight - (tileSize * 4), cloud5); //2
            AddSurface(10795, 607, cloud5);
            AddSurface(11185, 383, cloud5);

            #endregion

            #region Cathedral
            AddSurface(tileSize * 147, graphicsHeight, grass);
            AddSurface(30000, 600, cloud5);
            AddSurface(29404, 360, cloud5);
            AddSurface(29400, -273, cloud5);
            AddSurface(30581, 590, cloud5);
            AddSurface(30667, -400, cloud5);
            AddSurface(29765, 753, trans);
            AddSurface(30391, -170, trans);
            AddSurface(30000, 203, trans);

            #endregion

            #region stairways to heaven
            int shorter = 45;
            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (225 + i - shorter), graphicsHeight - (tileSize * i), 2);
                AddSurfaces(tileSize, graphicsHeight - (tileSize * i), dirt, 227 + i - shorter, 229 + i - shorter);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5),  grass, 231 - shorter, 232 - shorter);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 5), dirt, 233 - shorter, 234 - shorter);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 6),  grass, 233 - shorter, 237 - shorter);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileSize * (237 + i - shorter), graphicsHeight - (tileSize * (i + 6)), grass);
                AddSurfaces(tileSize, graphicsHeight - (tileSize * (i + 6)), dirt, 239 + i - shorter, 241 + i - shorter);
            }
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 11),  grass, 198, 200);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 12),  grass, 201, 215);
            AddSurfaces(tileSize, graphicsHeight - (tileSize * 11), dirt, 201, 215);


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
        /// <param name="spriteId">The sprite of the Surface</param>p
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


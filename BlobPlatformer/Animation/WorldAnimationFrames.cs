using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Animation
{
   public static class WorldAnimationFrames
    {
        public static List<Rectangle> CoinFrameList = new List<Rectangle>
            {new Rectangle(34, 32, 64, 64),
            {new Rectangle(120, 32, 57, 64)},
            {new Rectangle(199, 32, 50, 64)},
            {new Rectangle(271, 32, 44, 64)},
            {new Rectangle(337, 32, 39, 64)},
            {new Rectangle(396, 32, 33, 64)},
            {new Rectangle(451, 32, 29, 64)},
            {new Rectangle(502, 32, 23, 64)},
            {new Rectangle(547, 32, 16, 64)},
            {new Rectangle(585, 32, 23, 64)},
            {new Rectangle(630, 32, 29, 64)},
            {new Rectangle(680, 32, 33, 64)},
            {new Rectangle(734, 32, 39, 64)},
            {new Rectangle(795, 32, 44, 64)},
            {new Rectangle(861, 32, 50, 64)},
            {new Rectangle(933, 32, 57, 64)}

        };


        public static List<Rectangle> WaterFrameList = new List<Rectangle>
            {new Rectangle(1, 1, 128, 128),
            {new Rectangle(131, 1, 128, 128)},
            {new Rectangle(261, 1, 128, 128)},
            {new Rectangle(391, 1, 128, 128)},
            {new Rectangle(521, 1, 128, 128)},
            {new Rectangle(651, 1, 128, 128)},
            {new Rectangle(781, 1, 128, 128)},
            {new Rectangle(911, 1, 128, 128)},
            {new Rectangle(1041, 1, 128, 128)},
            {new Rectangle(1171, 1, 128, 128)},
            {new Rectangle(1301, 1, 128, 128)},
            {new Rectangle(1431, 1, 128, 128)},
            {new Rectangle(1561, 1, 128, 128)},
            {new Rectangle(1691, 1, 128, 128)}
        };

        public static List<Rectangle> StarGUI = new List<Rectangle>
            {new Rectangle(10,113, 129, 128),
        };

        public static List<Rectangle> Door = new List<Rectangle>
            {new Rectangle(160,116, 128, 119),
        };

        public static List<Rectangle> ChestFrameList = new List<Rectangle>
            {new Rectangle(63,64, 128, 128),
            {new Rectangle(217,59, 128, 133)},
            {new Rectangle(371,54, 128, 138)},
            {new Rectangle(525,46, 128, 146)},
            {new Rectangle(679,42, 128, 150)},
            {new Rectangle(833,40, 128, 152)},
        };

        public static List<Rectangle> UIFrameList = new List<Rectangle>
            {new Rectangle(243,25,258,64),
            {new Rectangle(243,159,258,64)},
            {new Rectangle(243,293,258,64)},
        };
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Animation
{
    public static class PlayerAnimationFrames
    {
        public static List<Rectangle> WalkFramesList = new List<Rectangle>
            {new Rectangle(61, 40, 66, 72),
            {new Rectangle(146, 40, 66, 74)},
            {new Rectangle(231, 40, 66, 75)},
            {new Rectangle(316, 39, 66, 76)},
            {new Rectangle(401, 38, 66, 77)},
            {new Rectangle(486, 37, 66, 78)},
            {new Rectangle(571, 38, 67, 77)},
            {new Rectangle(657, 39, 82, 76)},
            {new Rectangle(758, 40, 89, 72)},
            {new Rectangle(866, 40, 97, 72)},
            {new Rectangle(124, 140, 100, 74)},
            {new Rectangle(243, 139, 96, 76) },
            {new Rectangle(358, 138, 89, 77) },
            {new Rectangle(466, 137, 79, 78) },
            {new Rectangle(564, 136, 67, 79) },
            {new Rectangle(650, 137, 66, 78) },
            {new Rectangle(735, 138, 66, 76) },
            {new Rectangle(820, 139, 66, 71) }};

        public static List<Rectangle> IdleFramesList = new List<Rectangle>
            {new Rectangle(44, 28, 73, 74),
            {new Rectangle(130, 28, 73, 74)},
            {new Rectangle(217, 28, 73, 74)},
            {new Rectangle(303, 28, 73, 74)},
            {new Rectangle(389, 28, 73, 74)},
            {new Rectangle(476, 28, 73, 74)},
            {new Rectangle(562, 28, 73, 74)},
            {new Rectangle(649, 28, 73, 74)},
            {new Rectangle(735, 28, 73, 74)},
            {new Rectangle(821, 28, 73, 74)},
            {new Rectangle(908, 28, 73, 74)}
        };

        public static List<Rectangle> JumpFramesList = new List<Rectangle>
            {new Rectangle(37, 25, 76, 78)
        };

        public static List<Rectangle> FallFramesList = new List<Rectangle>
            {new Rectangle(152, 25, 67, 78)
        };


    }
}

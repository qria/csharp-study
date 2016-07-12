using Microsoft.VisualStudio.TestTools.UnitTesting;
using chsarp_study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsarp_study.Tests {
    [TestClass()]
    public class ProgramTests {
        [TestMethod()]
        public void PrintTowersTest() {
            int[][] towers = new int[][] {
                new int[] {3, 1, 1},
                new int[] {1 },
                new int[] {4, 3, 2, 1 }
            };
            String[] expectedScreen = {
                "    |      |       |     ",
                "    |      |       |     ",
                "    |      |       |     ",
                "    |      |       |     ",
                "    |      |       |     ",
                "    |      |       |     ",
                "    |      |      *|*    ",
                "   *|*     |     **|**   ",
                "   *|*     |    ***|***  ",
                " ***|***  *|*  ****|**** ",
            };
            String[] actualScreen = Program.GetScreen(towers, height:10);
            CollectionAssert.AreEqual(expectedScreen, actualScreen);
            
        }
    }
}
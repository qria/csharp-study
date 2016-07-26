using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace chsarp_study {
    public class Program {
        public static void PrintTowers(int[][] towers, int height = 0) {
            /* Draw towers
             * If height is not given, it is automatically determined to be the maximum height of the tower.
             */
            int maxTowerHeight = towers.Max(tower => tower.Length);
            if (height == 0) {
                height = maxTowerHeight;
            }

            // Raise error if impossible to draw
            if (height < maxTowerHeight) {
                throw new Exception(
                    String.Format("Given height({0}) is smaller than maximum tower height({1})", height, maxTowerHeight)
                );
            }

            String[] screen = GetScreen(towers, height);
            
            // Print screen
            foreach (string s in screen) {
                Console.WriteLine(s);
            }
        }

        public static String[] GetScreen(int[][] towers, int height) {
            /* Initialize screen an draw towers 
             * Refactored out for unit testing purposes.
             */

            // Initialize screen with empty strings
            String[] screen = new String[height];
            for (int i = 0; i < height; i++) {
                screen[i] = "";
            }

            // Buffer tower to screen
            foreach (int[] tower in towers) {
                BufferTower(screen, tower);
            }

            return screen;
        }

        static void BufferTower(string[] screen, int[] tower) {
            /* Draw given tower to screen
             * Assumes all strings in screen has is in same length,
             * and draws tower at the right side of the current screen.
             */
            var width = tower.Max();

            for (int i = 0; i < tower.Length; i++) {
                int diskSize = tower[i];
                string line =  RepeatString(" ", width - diskSize) 
                             + RepeatString("*", diskSize) 
                             + "|" 
                             + RepeatString("*", diskSize) 
                             + RepeatString(" ", width - diskSize);
                line = " " + line + " "; // add padding
                screen[screen.Length - 1 - i] += line;
            }
            for(int i = tower.Length; i < screen.Length; i++) {
                screen[screen.Length - 1 - i] += " " + RepeatString(" ", width) + "|" + RepeatString(" ", width) + " ";
            }
        }
        static string RepeatString(string s, int n) {
            return String.Concat(Enumerable.Repeat(s, n));
        }

    }
}
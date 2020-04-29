using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Pin
    {
        private const char hLineChar = '─';
        private const char tLineChar = '┴';
        private const char vLineChar = '│';
        private const char emptyChar = ' ';

        private string Name;
        private int height;
        public int width;
        private int center;

        List<Ring> Rings = new List<Ring>();


        public int X { get; set; }
        public int Y { get; set; }
        public Pin(string name, int height, int x=0, int y=0)
        {
            Name = name;
            this.height = height+3;
            X = x;
            Y = y;
            width = height * 2 + 3;
            center = (width - 1) / 2;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(X + x, Y + y);
                    if (y < height - 1)
                    {
                        Console.Write(x != center ? emptyChar : vLineChar);
                    }
                    else
                    {
                        Console.Write(x != center ? hLineChar : tLineChar);
                        if (x == center)
                        {
                            var length = Name.Length / 2;
                            Console.SetCursorPosition(X + x-length, Y + y + 1);
                            Console.Write(Name);
                        }
                    }
                }
            }
            for (int i = 0; i < Rings.Count; i++)
            {
                Rings[i].Draw(X, Y+height-2 - i);
            }

        }

        public void AddRing(Ring ring)
        {
            Rings.Add(ring);
        }

        public Ring GetRing()
        {
            Ring result;
            if (Rings.Count == 0) return null;
            result = Rings[^1];
            Rings.Remove(result);
            return result;
        }
    }
}
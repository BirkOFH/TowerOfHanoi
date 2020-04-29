using System;
using System.Drawing;

namespace ConsoleApp2
{
    public class Ring
    {
        private const char fillChar = '█';

        private int DefaultWidth;
        private int CurrWith;
        private ConsoleColor Color;
        private string Name;
        private int center;
        /// <summary>
        /// Конструктор кольца
        /// </summary>
        /// <param name="size">Размер кольца</param>
        /// <param name="color">Цвет</param>
        /// <param name="name">Название</param>
        public Ring(int size, ConsoleColor color, int defaultWidth)
        {
            if (size < 1) size = 1;

            CurrWith = size * 2 + 1;
            Color = color;
            DefaultWidth = defaultWidth;
            Name = size.ToString();
            center = (DefaultWidth - 1) / 2;
        }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.ForegroundColor = Color;
            int l = (DefaultWidth - CurrWith) / 2;
            int r = l + CurrWith;
            for (int i = 0; i < DefaultWidth; i++)
            {
                if (i < l || i >= r)
                {
                    Console.Write(" ");
                }
                else
                {
                    if (i != center)  Console.Write(fillChar); else Console.Write(Name);
                }
            }
        }
    }
}
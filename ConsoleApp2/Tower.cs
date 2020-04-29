using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Tower
    {
        private int Height;
        List<Pin> Pins = new List<Pin>();

        private int UpPinLine = 5;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="height">количество колец</param>
        public Tower(int height = 3)
        {
            SetHeight(height);
            //Создаем пины
            for (int i = 0; i < 3; i++)
                Pins.Add(new Pin((i+1).ToString(), height, i*50, UpPinLine));


            //Создаем кольца
            for (int i = height; i > 0; i--)
            {
                Pins[0].AddRing(new Ring(i, GetRandomConsoleColor(), Pins[0].width));
            }
        }

        public void SetHeight(int newHeight)
        {
            //проверки на дурака
            if (newHeight < 1) newHeight = 1;

            //Какой то конструктор
            Height = newHeight;
        }

        /// <summary>
        /// Рисуем какую то хрень
        /// </summary>
        public void StartDemonstration()
        {
            DrawCurrentState();
        }

        /// <summary>
        /// Рисуем текущее состояние башни
        /// </summary>
        private void DrawCurrentState()
        {
            Console.Clear();
            //рисуем пины
            for (int i = 0; i < Pins.Count; i++)
            {
                Pins[i].Draw();
            }

            //рисуем все кольца
            //for (int i = 0; i < Height; i++)
            //{
            //    Rings[i].Draw(1, DownPinLine-i);
            //}

        }

        private static Random _random = new Random();
        private static List<ConsoleColor> prevColors = new List<ConsoleColor>();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var result = ConsoleColor.White;
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            do
            {
                result = (ConsoleColor) consoleColors.GetValue(_random.Next(consoleColors.Length));
            }
            while (result == ConsoleColor.Black || prevColors.Contains(result));

            prevColors.Add(result);
            return result;
        }

        public void MoveRing(int fromIndex, int toIndex)
        {
            var source = Pins[fromIndex];
            var dest = Pins[toIndex];

            var ring = Pins[fromIndex].GetRing();
            if (ring == null) return;

            source.Draw();
            ring.Draw(source.X+1, source.Y);
            Task.Delay(100).Wait();
            source.Draw();
            //////////////////////////////////////////////
            ring.Draw(dest.X + 1, dest.Y);
            Task.Delay(100).Wait();
            //////////////////////////////////////////////
            dest.AddRing(ring);
            dest.Draw();
            Task.Delay(200).Wait();
        }

        public void Auto()
        {
            AutoMove(0, 1, 2, Height);
        }
        public void AutoMoveBase(int src, int free, int dst)
        {
            MoveRing(src, dst);
            MoveRing(src, free);
            MoveRing(dst, free);
            MoveRing(src, dst);
            MoveRing(free, src);
            MoveRing(free, dst);
            MoveRing(src, dst);
        }

        public void AutoMove(int src, int free, int dst, int count)
        {
            if (count < 3) return;
            if (count == 3) AutoMoveBase(src, free, dst); else
                while (true)
                {
                    if (count == 4)
                    {
                        AutoMoveBase(src, dst, free);
                        MoveRing(src, dst);
                        AutoMoveBase(free, src, dst);
                    }
                    else
                    {
                        AutoMove(src, dst, free, count - 1);
                        MoveRing(src, dst);
                        var src1 = src;
                        src = free;
                        free = src1;
                        count = count - 1;
                        continue;
                    }
                    break;
                }
        }
    }
}
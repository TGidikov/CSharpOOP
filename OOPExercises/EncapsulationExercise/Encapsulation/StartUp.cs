using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                var box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLeteralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

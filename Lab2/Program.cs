using System;

namespace Lab2
{
    // Variant #217

    // 20 70 4 40
    // Ymax = (30 - Nvar)*10 = 130
    // Ymin = (20 - Nvar)*10 = 30
    class Program
    {
        static void Main(string[] args)
        {
            int minX1 = 20;
            int maxX1 = 70;
            int minX2 = 5;
            int maxX2 = 40;
            int minY = 30;
            int maxY = 130;
            int yAmount = 6;

            Experiment experiment = new Experiment(minX1, maxX1, minX2, maxX2, minY, maxY, yAmount);
        }

    }
}

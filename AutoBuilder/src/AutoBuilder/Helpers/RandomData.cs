using System;

namespace AutoBuilder.Helpers
{
    public static class RandomData
    {
        private static readonly Random _random = new Random(DateTime.UtcNow.GetHashCode());

        public static int GetInt() => _random.Next();
        public static int GetInt(int max) => _random.Next(max);
        public static int GetInt(int min, int max) => _random.Next(min, max);
        public static double GetDouble() => _random.NextDouble();
        public static bool GetBool() => _random.Next() % 2 == 0;
    }
}

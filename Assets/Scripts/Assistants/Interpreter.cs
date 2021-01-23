using System;

namespace Asteroids
{
    public static class Interpreter
    {
        public static string Rewrite(float number)
        {
            if (number > 999999999) return "unreal score!!!";
            if (number < 1) return String.Empty;

            if (number < 1000) return $"{number}";

            int num = (int) number / 1000000;
            if (num >= 1) return $"{num}M";

            num = (int) number / 1000;
            if (num >= 1) return $"{num}K";

            throw new ArgumentOutOfRangeException(nameof(number));
        }
    }
}

using Godot;

namespace CMC.Tools
{
    public static class MathX
    {
        public static int MakeOddUp(int x)
        { return x % 2 == 0 ? x + 1 : x; }

        public static int MakeOddDown(int x)
        { return x % 2 == 0 ? x - 1 : x; }

        public static int RandomOdd(int min, int max)
        { return MakeOddUp(_rng.RandiRange(min, max)); }

        public static bool RandomBool()
        { return _rng.Randf() > 0.5f; }

        public static float RandomFloat()
        { return _rng.Randf(); }

        public static float RandomRange(float min, float max)
        { return _rng.RandfRange(min, max); }

        public static int RandomRange(int min, int max)
        { return _rng.RandiRange(min, max); }


        private readonly static RandomNumberGenerator _rng = CreateRNG();

        private static RandomNumberGenerator CreateRNG()
        {
            var rng = new RandomNumberGenerator();
            rng.Randomize();
            return rng;
        }
    }
}
namespace DreamHub
{
    public static class GravityReference
    {
        public static float Current { get { return _current; } }
        private static float _current = -9.81f;
        private const float _defaultValue = -9.81f;

        public static void Set(DreamModeManager.DreamMode dreamMode)
        {
            _current = GetGravityByMode(dreamMode);
        }

        private static float GetGravityByMode(DreamModeManager.DreamMode dreamMode)
        {
            return dreamMode switch
            {
                DreamModeManager.DreamMode.Normal => _defaultValue,
                DreamModeManager.DreamMode.Lucid => _defaultValue / 4f,
                _ => _defaultValue
            };
        }
    }
}
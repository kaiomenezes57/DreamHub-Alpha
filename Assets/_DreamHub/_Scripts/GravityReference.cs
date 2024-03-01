using DreamHub.Dream;

namespace DreamHub
{
    public static class GravityReference
    {
        public static float Current { get { return _current; } }
        private static float _current;
        private const float _defaultValue = -10f;

        public static void Set(DreamModeManager.DreamMode dreamMode)
        {
            _current = GetGravityByMode(dreamMode);
        }

        private static float GetGravityByMode(DreamModeManager.DreamMode dreamMode)
        {
            return dreamMode switch
            {
                DreamModeManager.DreamMode.Normal => _defaultValue,
                DreamModeManager.DreamMode.Lucid => _defaultValue / 3f,
                _ => _defaultValue
            };
        }
    }
}
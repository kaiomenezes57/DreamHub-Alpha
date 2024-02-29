namespace DreamHub
{
    public sealed class DreamModeManager : Singleton<DreamModeManager>
    {
        public enum DreamMode { Normal = 0, Lucid = 1, }
        public DreamMode Current { get; private set; }

        public void Set(DreamMode dreamMode)
        {
            Current = dreamMode;
            GravityReference.Set(dreamMode);
        }
    }
}
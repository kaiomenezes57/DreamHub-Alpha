namespace DreamHub
{
    public sealed class PlayerDeathTrigger : TriggerBase
    {
        protected override void Trigger()
        {
            WinOrLooseManager.OnPlayerDied();
        }
    }
}

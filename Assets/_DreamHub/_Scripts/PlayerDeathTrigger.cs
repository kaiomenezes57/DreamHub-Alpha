using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game.Trigger
{
    public class EndGameTrigger : TriggerBase
    {
        protected override void OnTriggered()
        {
            Application.Quit();
        }
    }
}
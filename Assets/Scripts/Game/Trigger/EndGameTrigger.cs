using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Trigger
{
    public class EndGameTrigger : TriggerBase
    {
        protected override void OnTriggered()
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
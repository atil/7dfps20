using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class PlaySfxTrigger : TriggerBase
    {
        public AudioSource AudioSource;

        void Start()
        {
            if (AudioSource == null && !this.TryGetComponentInChildren(out AudioSource))
            {
                Debug.LogError($"Couldn't find audiosource with this sfx trigger {name}");
            }
        }

        protected override void OnTriggered()
        {
            AudioSource.Play();
        }
    }
}
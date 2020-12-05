using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class PlaySfxTrigger : TriggerBase
    {
        private AudioSource _audioSource;

        void Start()
        {
            if (!this.TryGetComponentInChildren(out _audioSource)) {
                Debug.LogError($"Couldn't find audiosource with this sfx trigger {name}");
            }
        }

        protected override void OnTriggered()
        {
            _audioSource.Play();
        }
    }
}
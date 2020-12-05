using UnityEngine;
using System.Collections;

public abstract class TriggerBase : MonoBehaviour
{
    private bool _isTriggered = false;

    void OnTriggerEnter(Collider collider)
    {
        if (_isTriggered)
        {
            return;
        }

        _isTriggered = true;
        OnTriggered();
    }

    protected abstract void OnTriggered();
}
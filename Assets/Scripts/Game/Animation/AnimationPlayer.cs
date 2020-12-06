using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AnimKeyframe
{
    public Vector3 Position;
    public Quaternion Rotation;
}

public class AnimationPlayer : MonoBehaviour
{
    public List<AnimKeyframe> Keyframes = new List<AnimKeyframe>();
    public AnimationCurve AnimCurve;
    public float Duration;

    public void Play(bool playEndSound)
    {
        if (Keyframes.Count == 0)
        {
            return;
        }

        AnimKeyframe sourceFrame = Keyframes[0];
        AnimKeyframe targetFrame = Keyframes[1];

        Curve.Tween(AnimCurve, Duration,
            (t) =>
            {
                transform.position = Vector3.Lerp(sourceFrame.Position, targetFrame.Position, t);
                transform.rotation = Quaternion.Lerp(sourceFrame.Rotation, targetFrame.Rotation, t);
            },
            () =>
            {
                transform.position = targetFrame.Position;
                transform.rotation = targetFrame.Rotation;

                if (playEndSound && TryGetComponent(out AudioSource audioSource))
                {
                    audioSource.Play();
                }
            });

    }

}
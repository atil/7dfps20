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
    public List<AnimKeyframe> Keyframes; 

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

        float y = transform.position.y; // Needs to be kept due to usher jumping

        Curve.Tween(AnimCurve, Duration,
            (t) =>
            {
                transform.position = Vector3.Lerp(sourceFrame.Position, targetFrame.Position, t).WithY(y);
                transform.rotation = Quaternion.Lerp(sourceFrame.Rotation, targetFrame.Rotation, t);
            },
            () =>
            {
                transform.position = targetFrame.Position.WithY(y);
                transform.rotation = targetFrame.Rotation;

                if (playEndSound && TryGetComponent(out AudioSource audioSource))
                {
                    audioSource.Play();
                }
            });

    }

}
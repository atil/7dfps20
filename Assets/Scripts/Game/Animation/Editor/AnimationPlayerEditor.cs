using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationPlayer))]
public class AnimationPlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AnimationPlayer animPlayer = (AnimationPlayer)target;

        if (GUILayout.Button("Clear"))
        {
            animPlayer.Keyframes.Clear();
        }

        if (GUILayout.Button("Add"))
        {
            animPlayer.Keyframes.Add(new AnimKeyframe 
            { 
                Position = animPlayer.transform.position,
                Rotation = animPlayer.transform.rotation
            });
        }
    }
}
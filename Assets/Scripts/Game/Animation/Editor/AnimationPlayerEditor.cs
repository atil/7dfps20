using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(AnimationPlayer))]
public class AnimationPlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AnimationPlayer animPlayer = (AnimationPlayer)target;

        if (animPlayer.Keyframes == null)
        {
            animPlayer.Keyframes = new List<AnimKeyframe>();
        }

        if (GUILayout.Button("Clear"))
        {
            animPlayer.Keyframes.Clear();
            this.serializedObject.ApplyModifiedProperties();
        }

        if (GUILayout.Button("Add"))
        {
            animPlayer.Keyframes.Add(new AnimKeyframe 
            { 
                Position = animPlayer.transform.position,
                Rotation = animPlayer.transform.rotation
            });
            this.serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(animPlayer);
        }

    }
}
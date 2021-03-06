﻿using UnityEngine;
using System.Collections;

public enum UsherSpookState
{
    None,
    WaitingToTeleport,
    WaitingToBeSeen,
    Spooked
}

public class Usher : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Texture2D[] Textures;
    public Transform Quad;

    [HideInInspector]
    public bool IsLookingAtPlayer;

    private Transform _playerTransform;

    public UsherSpookState SpookState;

    [Header("Jump")]
    public bool IsJumping = false;
    public AnimationCurve JumpCurve;
    public float JumpHeight = 4f;

    void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;

        if (IsJumping)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    private IEnumerator JumpCoroutine()
    {
        float baseY = transform.position.y;
        const float jumpDuration = 0.5f;
        for (float f = 0;;f += Time.deltaTime)
        {
            float t = JumpCurve.Evaluate(f / jumpDuration);
            float y = Mathf.Lerp(baseY, JumpHeight, t);
            transform.position = transform.position.WithY(y);

            if (f > jumpDuration)
            {
                f = 0f;
            }
            yield return null;
        }

    }

    void Update()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).WithY(0).normalized;

        Quad.rotation = Quaternion.LookRotation(-toPlayer);

        if (!IsLookingAtPlayer)
        {
            SetTextureFromPlayer(toPlayer);
        }
    }

    private void SetTextureFromPlayer(Vector3 toPlayer)
    {
        float angle = Vector3.SignedAngle(transform.forward, -toPlayer, Vector3.up);
        angle = (angle + 360) % 360;

        int textureIndex;
        if (angle < 22.5f)
        {
            textureIndex = 0;
        }
        else if (angle < 22.5 + 45f)
        {
            textureIndex = 1;
        }
        else if (angle < 22.5 + 45f * 2)
        {
            textureIndex = 2;
        }
        else if (angle < 22.5 + 45f * 3)
        {
            textureIndex = 3;
        }
        else if (angle < 22.5 + 45f * 4)
        {
            textureIndex = 4;
        }
        else if (angle < 22.5 + 45f * 5)
        {
            textureIndex = 5;
        }
        else if (angle < 22.5 + 45f * 6)
        {
            textureIndex = 6;
        }
        else if (angle < 22.5 + 45f * 7)
        {
            textureIndex = 7;
        }
        else
        {
            textureIndex = 0;
        }

        Renderer.material.SetTexture("_MainTex", Textures[textureIndex]);

    }

    public void OnVisible()
    {
        if (SpookState != UsherSpookState.WaitingToBeSeen)
        {
            return;
        }

        FindObjectOfType<Sfx>().UsherSpook();
        SpookState = UsherSpookState.Spooked;
    }

}
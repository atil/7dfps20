using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class Usher : MonoBehaviour
    {
        public MeshRenderer Renderer;
        public Texture2D[] Textures;
        public Transform Quad;

        private Transform _playerTransform;

        void Start()
        {
            _playerTransform = FindObjectOfType<Player>().transform;
        }

        void Update()
        {
            Vector3 toPlayer = (_playerTransform.position - transform.position).WithY(0).normalized;

            Quad.rotation = Quaternion.LookRotation(-toPlayer);

            float angle = Vector3.SignedAngle(transform.forward, -toPlayer, Vector3.up);
            angle = (angle + 360) % 360;

            int textureIndex = 0;
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

    }
}
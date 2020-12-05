using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Walkthrough : MonoBehaviour
{
    public Transform PlayerStart;

    public EndWalkthroughTrigger EndTrigger;

    public void Init()
    {
        gameObject.SetActive(true);
        Player player = FindObjectOfType<Player>();
        player.ResetAt(PlayerStart);
    }

    public void Dispose()
    {
        gameObject.SetActive(false);
    }

    void OnDrawGizmos()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (PlayerStart != null)
        {
            Gizmos.DrawWireSphere(PlayerStart.position, 1f);
        }
    }
}

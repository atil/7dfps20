using UnityEngine;
using System.Collections;

public class UsherRenderer : MonoBehaviour
{
    private void OnBecameVisible()
    {
        GetComponentInParent<Usher>().OnVisible();
    }
}

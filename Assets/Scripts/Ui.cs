using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private Image _flashImage;

    [SerializeField]
    private FlashInfo _startFlashInfo;

    public TextMeshProUGUI Text;

    public void StartFlash()
    {
        Curve.Tween(_startFlashInfo.Curve, _startFlashInfo.Duration,
            (t) =>
            {
                _flashImage.color = Color.Lerp(_startFlashInfo.StartColor, _startFlashInfo.EndColor, t);
            },
            () =>
            {
                _flashImage.color = _startFlashInfo.EndColor;
            });
    }

    public void ShowText(string text, float duration)
    {
        CoroutineStarter.Run(ShowTextCoroutine(text, duration));
    }

    private IEnumerator ShowTextCoroutine(string text, float duration)
    {
        Text.gameObject.SetActive(true);
        Text.text = text;
        yield return new WaitForSeconds(duration);
        Text.gameObject.SetActive(false);
    }

}

[Serializable]
public class FlashInfo
{
    public Color StartColor;
    public Color EndColor;
    public float Duration;
    public AnimationCurve Curve;
}

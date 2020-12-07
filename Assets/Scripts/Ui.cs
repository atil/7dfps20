using Kino;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FlashInfo
{
    public Color StartColor;
    public Color EndColor;
    public float Duration;
    public AnimationCurve Curve;
}

public class Ui : MonoBehaviour
{
    [SerializeField]
    private Image _flashImage;

    [SerializeField]
    private FlashInfo _startFlashInfo;

    [SerializeField]
    private FlashInfo _transitionFlashInfo;

    [SerializeField]
    private AnalogGlitch _analogGlitch;

    [SerializeField]
    private DigitalGlitch _digitalGlitch;

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

    public void TransitionFlash()
    {
        Curve.Tween(_transitionFlashInfo.Curve, _transitionFlashInfo.Duration,
            (t) =>
            {
                _flashImage.color = Color.Lerp(_transitionFlashInfo.StartColor, _transitionFlashInfo.EndColor, t);
            },
            () =>
            {
                _flashImage.color = _transitionFlashInfo.EndColor;
            });
    }
    public void ClearFlash()
    {
        _flashImage.color = Color.clear;
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

    public void Glitch(float duration)
    {
        CoroutineStarter.Run(GlitchCoroutine(duration));
    }

    private IEnumerator GlitchCoroutine(float duration)
    {
        _analogGlitch.scanLineJitter = 0.5f;
        _analogGlitch.colorDrift = 0.2f;
        _digitalGlitch.intensity = 0.5f;

        yield return new WaitForSeconds(duration);

        _analogGlitch.scanLineJitter = 0f;
        _analogGlitch.colorDrift = 0f;
        _digitalGlitch.intensity = 0f;
    }

}

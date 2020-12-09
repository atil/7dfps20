using UnityEngine;
using System.Collections;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TextMeshProUGUI CreditsText;
    public TextMeshProUGUI ThankYouText;
    public AudioSource AudioSource;

    private bool _isAbleToQuit = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        AudioSource.Play();
        CreditsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        AudioSource.Play();
        CreditsText.gameObject.SetActive(false);
        ThankYouText.gameObject.SetActive(true);
        _isAbleToQuit = true;
    }

    private void Update()
    {
        if (_isAbleToQuit && Input.anyKey)
        {
            Application.Quit();
        }
    }

}

using UnityEngine;
using UnityEngine.UI;

public class controleDeAudio : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundFloat;
    public AudioSource backgroundAudio;
    public Sprite volumeON, volumeOFF;
    public Button btnVolume;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            verificaVolume();
        }

        if (backgroundSlider.value == 0)
        {
            UpdateSound();
        }
    }
    void OnApplicationFocus(bool inFocus)
        {
            if (!inFocus) {
                SaveSoundSettings();
            }
        }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
    }

    public void verificaVolume()
    {
        if(backgroundSlider.value == 0)
        {
            btnVolume.image.sprite = volumeOFF;
        }
        else
        {
            btnVolume.image.sprite = volumeON;
        }
    }
}

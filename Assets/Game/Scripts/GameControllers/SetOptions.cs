using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetOptions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown ResolutionCamp = null;
    [SerializeField] Toggle VSyncCamp = null;
    [SerializeField] Toggle AntiAliasingCamp = null;
    [SerializeField] Slider MusicVolCamp = null;
    [SerializeField] Slider FxVolCamp = null;
    bool isOnVSync = false;
    bool isOnAntiAliasing = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("VSync"))
        {
            PlayerPrefs.SetInt("VSync", 1);
        }
        if (!PlayerPrefs.HasKey("AntiAliasing"))
        {
            PlayerPrefs.SetInt("AntiAliasing", 1);
        }
        if (!PlayerPrefs.HasKey("Resolution"))
        {
            PlayerPrefs.SetInt("Resolution", 0);
        }
        if (!PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.SetFloat("musicVol", 1.0f);
        }
        if (!PlayerPrefs.HasKey("fxVol"))
        {
            PlayerPrefs.SetFloat("fxVol", 1.0f);
        }



        if (PlayerPrefs.GetInt("VSync") >= 1)
        {
            isOnVSync = true;
        }
        else
        {
            isOnVSync = false;
        }
        if (PlayerPrefs.GetInt("AntiAliasing") >= 1)
        {
            isOnAntiAliasing = true;
        }
        else
        {
            isOnAntiAliasing = false;
        }
        ResolutionCamp.value = PlayerPrefs.GetInt("Resolution");
        VSyncCamp.isOn = isOnVSync;
        AntiAliasingCamp.isOn = isOnAntiAliasing;
        MusicVolCamp.value = PlayerPrefs.GetFloat("musicVol");
        FxVolCamp.value = PlayerPrefs.GetFloat("fxVol");

    }

    public void ChangeResolution(TMP_Dropdown m_Dropdown)
    {
        switch (m_Dropdown.value)
        {
            case 0:
                Screen.SetResolution(1300, 800, true);
                Debug.Log("Tela Cheia");
                PlayerPrefs.SetInt("Resolution", 0);
                break;
            case 1:
                Screen.SetResolution(1300, 800, FullScreenMode.ExclusiveFullScreen, 60);
                Debug.Log("Maximizada");
                PlayerPrefs.SetInt("Resolution", 1);
                break;
            case 2:
                Screen.SetResolution(1300, 800, false);
                Debug.Log("Modo Janela");
                PlayerPrefs.SetInt("Resolution", 2);
                break;
            default:
                Screen.SetResolution(1300, 800, true);
                break;
        }

    }
    public void ChangeVSync(Toggle m_toggle)
    {
        if (m_toggle.isOn == true)
        {
            QualitySettings.vSyncCount = 1;
            Debug.Log("VSync On");
            PlayerPrefs.SetInt("VSync", 1);
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Debug.Log("VSync Off");
            PlayerPrefs.SetInt("VSync", 0);
        }
    }
    public void ChangeAntiAliasing(Toggle m_toggle)
    {
        if (m_toggle.isOn == true)
        {
            QualitySettings.antiAliasing = 2;
            Debug.Log("antiAliasing On");
            PlayerPrefs.SetInt("AntiAliasing", 1);
        }
        else
        {
            QualitySettings.antiAliasing = 1;
            Debug.Log("antiAliasing Off");
            PlayerPrefs.SetInt("AntiAliasing", 0);
        }

    }
    
    /*public void ChangeVolumeMusic(Slider m_slider)
    {
        SoundManager.instance.musicSource.volume = m_slider.value;
        PlayerPrefs.SetFloat("musicVol", m_slider.value);
    }
    public void ChangeVolumeFx(Slider m_slider)
    {
        SoundManager.instance.efxSource.volume = m_slider.value;
        PlayerPrefs.SetFloat("fxVol", m_slider.value);
    }*/

}

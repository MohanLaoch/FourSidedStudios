using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,

        MUSIC,

        AMBIENCE,

        SFX
    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;
    //public SceneInfo sceneInfo;
    private void Awake()
    {
        volumeSlider = this.GetComponent<Slider>();
       // volumeSlider.value = sceneInfo.musicVolume;
    }

    /*public void LoadData(GameData data)
    {
        volumeSlider.value = data.volumeSliderValue;
    }

    public void SaveData(GameData data)
    {
        data.volumeSliderValue = volumeSlider.value;
    }*/




    private void Update()
    {
        switch(volumeType)
        {
            case VolumeType.MASTER:
                volumeSlider.value = AudioManager.instance.masterVolume;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioManager.instance.musicVolume;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                volumeSlider.value = AudioManager.instance.ambienceVolume;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.instance.SFXVolume;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            default:
                Debug.LogWarning("Volume Type not supported: " + volumeType);
                break;

        }
        Debug.Log(volumeSlider.value);
    }

    public void OnSliderValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.instance.masterVolume = volumeSlider.value;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.instance.musicVolume = volumeSlider.value;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                AudioManager.instance.ambienceVolume = volumeSlider.value;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.instance.SFXVolume = volumeSlider.value;
                //sceneInfo.musicVolume = volumeSlider.value;
                break;
            default:
                Debug.LogWarning("Volume Type not supported: " + volumeType);
                break;

        }
    }





}

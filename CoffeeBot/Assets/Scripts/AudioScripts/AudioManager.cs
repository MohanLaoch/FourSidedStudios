using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]

    public float masterVolume = 1;
    [Range(0, 1)]

    public float musicVolume = 1;
    [Range(0, 1)]

    public float ambienceVolume = 1;
    [Range(0, 1)]

    public float SFXVolume = 1;
    [Range(0, 1)]

    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxBus;


    public SceneInfo sceneInfo;
    public GameObject Radio;
    private List<EventInstance> eventInstances;


    private List<StudioEventEmitter> eventEmitters;


    private EventInstance musicEventInstance;
    public static AudioManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/MusicBus");
        ambienceBus = RuntimeManager.GetBus("bus:/AmbienceBus");
        sfxBus = RuntimeManager.GetBus("bus:/SFXBus");

        InitializeMusic(FMODEvents.instance.Radio);

    }

    private void Start()
    {
        //InitializeMusic(FMODEvents.instance.Radio);
        masterVolume = sceneInfo.masterVolume;

        musicVolume = sceneInfo.musicVolume;

        ambienceVolume = sceneInfo.ambienceVolume;

        SFXVolume = sceneInfo.SFXVolume;
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        sceneInfo.masterVolume = masterVolume;

        musicBus.setVolume(musicVolume);
       sceneInfo.musicVolume = musicVolume;

        ambienceBus.setVolume(ambienceVolume);
        sceneInfo.ambienceVolume = ambienceVolume;

        sfxBus.setVolume(SFXVolume);
        sceneInfo.SFXVolume = SFXVolume;

    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        RuntimeManager.AttachInstanceToGameObject(musicEventInstance, Radio.transform);
        musicEventInstance.start();
        
    }
    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    public void SetMusicArea(MusicArea area)
    {
        musicEventInstance.setParameterByName("area", (float) area);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }


    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    public void SetMusicParameter(string ParamName, float ParamValue)
    {
        musicEventInstance.setParameterByName(ParamName, ParamValue);
    }
}
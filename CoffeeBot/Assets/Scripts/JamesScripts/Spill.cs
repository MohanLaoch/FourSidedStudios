using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class Spill : MonoBehaviour
{
    public GameObject spiltCoffee;
    private GameObject mop;

    public ParticleSystem spillEffect;

    private EventInstance spillSound;

    [SerializeField]
    private int layerNumber = 9; // Ground is currently 9

    private void Awake()
    {
        mop = GameObject.FindGameObjectWithTag("Mop");
        
    }

    private void Start()
    {
        spillSound = AudioManager.instance.CreateInstance(FMODEvents.instance.CoffeeSFX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (other.gameObject.layer == layerNumber)
        {
            mop.GetComponent<RoboMop>().SpillDetected = true;
            mop.GetComponent<RoboMop>().SlipperyFloor = spiltCoffee;
            Instantiate(spiltCoffee, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            spillEffect.Play();
            UpdateSpillSound();
            
            //send signal to robomop!!
        }
    }

    private void UpdateSpillSound()
    {

        PLAYBACK_STATE playbackState;
        spillSound.getPlaybackState(out playbackState);
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            spillSound.start();
        }
    }
}

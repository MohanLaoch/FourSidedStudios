using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetMusicAreaTrigger : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private MusicArea area;




    public void Start()
    {
        AudioManager.instance.SetMusicArea(area);
        Debug.Log("Bungus");
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Arms SFX")]

    [field: SerializeField] public EventReference armRisingSound { get; private set; }

    [field: SerializeField] public EventReference grabSound { get; private set; }

    [field: Header("Flip SFX")]

    [field: SerializeField] public EventReference Flip { get; private set; }

    [field: Header("Drive SFX")]
    [field: SerializeField] public EventReference Drive { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference DayToEvening { get; private set; }


    [field: Header("NPCSFX")]
    [field: SerializeField] public EventReference NPC { get; private set; }


    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one FMOD events instance in the scene");
        }
        instance = this;
    }
}

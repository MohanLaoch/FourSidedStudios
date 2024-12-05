using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftMove2 : MonoBehaviour
{
    public string keyTag;

    public Animator forkliftAnimator;

    public string animationName;

    public Transform ForkliftSpotTransform;

    public Player player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mop"))
        {
            forkliftAnimator.Play(animationName);           
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftMove : MonoBehaviour
{
    public string keyTag;

    public Animator forkliftAnimator;

    public string animationName;

    public Transform ForkliftSpotTransform;

    public Player player;

    public void OnTriggerStay(Collider other)
    {
        if(!player.Holding)
        {
            forkliftAnimator.Play(animationName);

            other.transform.position = ForkliftSpotTransform.position;
        }

    }
}

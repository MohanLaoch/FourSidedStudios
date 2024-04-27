using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrier : MonoBehaviour
{
    public string keyTag;

    public Animator barrierAnimator;

    public string animationName;

    public GameObject controlsText;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == keyTag)
        {
            barrierAnimator.Play(animationName);

            controlsText.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public int seconds = 10;

    private void Awake()
    {
        destroySelf();
    }

    private IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }


}

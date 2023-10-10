using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePastObjects : MonoBehaviour
{
    public GameObject camera;
    public GameObject target;
    public LayerMask myLayerMask;

    // I likely will revist this or just delete this script and replace it with something else
    // https://www.youtube.com/watch?v=0rEF8A3wF9U&ab_channel=DanielSantalla - I used this for the code here
    // https://www.youtube.com/watch?v=jidloC6gyf8&ab_channel=DanielIlett - this seems more promising

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, (target.transform.position - camera.transform.position).normalized, out hit, Mathf.Infinity, myLayerMask))
        {
            if (hit.collider.gameObject.tag == "spheremask")
            {
                //target.transform.DOScale(0, 2);
            }
            else
            {
                //target.transform.DOScale(10, 2);
            }
        }
    }
}

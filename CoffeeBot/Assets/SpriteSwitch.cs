using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite[] daySprites;
    public SceneInfo sceneInfo;
    public Sprite currentSprite;


    private void Start()
    {
    }
    private void Update()
    {
        switch (sceneInfo.dayCount)
        {


            case 0:
                currentSprite = daySprites[5];
                break;
            case 1:
            currentSprite = daySprites[0];
                break;
            case 2:
            currentSprite = daySprites[1];
                break;
            case 3:
                currentSprite = daySprites[2];
                break;
            case 4:
                currentSprite = daySprites[3];
                break;
            case 5:
                currentSprite = daySprites[4];
                break;

        }

        GetComponent<Image>().sprite = currentSprite;

    }
}

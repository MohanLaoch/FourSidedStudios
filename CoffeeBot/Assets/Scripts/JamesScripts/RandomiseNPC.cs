using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseNPC : MonoBehaviour
{
    [Header("Body Textures")]

    public Renderer meshRenderer;

    public Material[] bodyTextures;

    [Header("Clothing GameObjects")]

    public GameObject[] headObjects;
    public GameObject[] torsoObjects;
    public GameObject[] legObjects;
    public GameObject[] rFeetObjects;
    public GameObject[] lFeetObjects;


    public void Awake()
    {
        AssignBodyTexture();
        AddHeadObject();
        AddTorsoObject();
        AddLegObject();
        AddFeetObject();
    }

    public void AssignBodyTexture()
    {
        int randomIndex = Random.Range(0, bodyTextures.Length);

        Material body = bodyTextures[randomIndex];

        meshRenderer.material = body;
    }

    public void AddHeadObject()
    {
        int randomIndex = Random.Range(0, headObjects.Length);

        GameObject head = headObjects[randomIndex];

        head.gameObject.SetActive(true);
    }

    public void AddTorsoObject()
    {
        int randomIndex = Random.Range(0, torsoObjects.Length);

        GameObject torso = torsoObjects[randomIndex];

        torso.gameObject.SetActive(true);
    }

    public void AddLegObject()
    {
        int randomIndex = Random.Range(0, legObjects.Length);

        GameObject leg = legObjects[randomIndex];

        leg.gameObject.SetActive(true);
    }

    public void AddFeetObject()
    {
        int randomIndex = Random.Range(0, rFeetObjects.Length);

        GameObject rFeet = rFeetObjects[randomIndex];
        GameObject lFeet = rFeetObjects[randomIndex];


        rFeet.gameObject.SetActive(true);
        lFeet.gameObject.SetActive(true);

    }

}

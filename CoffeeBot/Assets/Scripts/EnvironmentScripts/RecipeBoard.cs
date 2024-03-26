using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RecipeBoard : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    public GameObject recipeBoardUI;

    public Image recipeBoardImage;

    public bool can;
    

    private void Awake()
    {
        recipeBoardUI.SetActive(false);

    }

    private void Start()
    {
        action.performed += ctx => TurnOnRecipeBoard();

    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void TurnOnRecipeBoard()
    {
        

        if (can)
        {          
            recipeBoardImage.gameObject.SetActive(true);
            action.Enable();
        }
        else if (!can)
        {
            
            recipeBoardImage.gameObject.SetActive(false);
            action.Disable();
            
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            recipeBoardUI.SetActive(true);
            can = true;
           
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            can = false;
            recipeBoardUI.SetActive(false);
            recipeBoardImage.gameObject.SetActive(false);
            
        }
        
    }
}

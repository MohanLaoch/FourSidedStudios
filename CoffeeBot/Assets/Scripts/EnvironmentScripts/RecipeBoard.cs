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

    private bool can;
    private bool inCollider;

    private void Awake()
    {
        inCollider = false;
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
        if (inCollider)
        {
            if (can)
            {
                recipeBoardImage.gameObject.SetActive(true);
                can = false;

            }
            else if (!can)
            {
                recipeBoardImage.gameObject.SetActive(false);
                can = true;

            }
        }        
    }

    public void OnTriggerEnter(Collider other)
    {
        inCollider = true;

        if (other.gameObject.tag == "Player")
        {
            recipeBoardUI.SetActive(true);
            can = true;
           
        }
    }

    public void OnTriggerExit(Collider other)
    {
        inCollider = false;

        if (other.gameObject.tag == "Player")
        {
            can = false;
            recipeBoardUI.SetActive(false);
            recipeBoardImage.gameObject.SetActive(false);
            
        }
        
    }
}

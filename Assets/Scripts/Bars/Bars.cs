using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bars : MonoBehaviour
{
    private IInterable interable;
    private PlayerAction actions;
    private bool InteractOn;

    void Awake()
    {
        actions = new PlayerAction();
    }
    public void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Interaction.performed += OnInteract;
    }

    public void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Interaction.canceled -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
        => InteractOn = true;

    private void Start()
    {
        interable = GetComponent<IInterable>();
    }


    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (interable != null)
            { 
                interable.ChangeLight(true);

                if (InteractOn)
                    interable.Interact();
            }
        }   
    }

    private void OnCollisionStay(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (interable != null)
            {
                if (InteractOn)
                { 
                    interable.Interact(); 
                    InteractOn = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }    

    private void OnCollisionExit(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (interable != null)
            {
                interable.ChangeLight(false);
            }
        }

        InteractOn = false;
    }
}

using UnityEngine;
public class Bars : MonoBehaviour
{
    private IInterable interable;
    private PlayerAction actions;


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
            }
        }
    }

    private void OnCollisionStay(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (interable != null)
            {
                var player = other.gameObject.GetComponent<PlayerMovement>();

                if (player.IsInteractOn())
                {
                    interable.Interact();
                    player.ResetInteract();
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
    }
}
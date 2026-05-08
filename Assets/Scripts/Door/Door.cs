using UnityEngine;

public class Door : MonoBehaviour
{
    private IInterable interable;
    private PlayerAction actions;

    private void Start()
    {
        interable = GetComponent<IInterable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (interable != null)
            {
                interable.ChangeLight(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (interable != null)
            {
                interable.ChangeLight(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
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
}

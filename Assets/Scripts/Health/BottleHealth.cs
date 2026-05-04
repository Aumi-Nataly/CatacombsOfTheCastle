using UnityEngine;

public class BottleHealth : MonoBehaviour
{
    private IInterable interable;

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
                interable.Interact();
            }
        }
    }
}

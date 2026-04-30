using UnityEngine;

public class Bars : MonoBehaviour
{
    private IInterable interable;

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

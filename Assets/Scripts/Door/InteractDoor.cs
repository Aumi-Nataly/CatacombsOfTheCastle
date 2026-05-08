using UnityEngine;


public class InteractDoor : MonoBehaviour, IInterable
{
    [SerializeField]
    private string NextLvlName;
    
    [SerializeField]
    private GameObject childTransform;
    Light lightComponent;

    void Awake()
    {     
        lightComponent = childTransform?.GetComponent<Light>();
        lightComponent.enabled = false;
    }

    public void ChangeLight(bool enable)
    {
        lightComponent.enabled = enable;
       Debug.Log("Верь светится");
    }

    public string GetInteractPromt()
    {
        return "";
    }

    public void Interact()
    {
        
    }
}

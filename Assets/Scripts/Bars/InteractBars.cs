using UnityEngine;
using UnityEngine.InputSystem;

public class InteractBars : MonoBehaviour, IInterable
{
    [SerializeField]
    private Material normalMaterial;

    [SerializeField]
    private Material hightligthMaterial;

    private Renderer renderer;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = normalMaterial;
    }


    public void ChangeLight(bool enable)
    {
        renderer.material = enable ? renderer.material = hightligthMaterial : normalMaterial;
    }

    public string GetInteractPromt()
    {
        return "Активировать ключ";
    }

    public void Interact()
    {
         Debug.Log("решетка нажата");
 
    }
}

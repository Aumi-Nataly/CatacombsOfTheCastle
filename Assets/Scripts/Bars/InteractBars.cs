using UnityEngine;
using VContainer;

public class InteractBars : MonoBehaviour, IInterable
{
    [SerializeField]
    private int Id;

    [SerializeField]
    private Material normalMaterial;

    [SerializeField]
    private Material hightligthMaterial;

    private Renderer renderer;


    private IInventoryService _inventoryService;

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }



    void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = normalMaterial;
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("bars_" + Id.ToString(), 0) == 1)
        {
            gameObject.SetActive(false);
        }
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
        if (_inventoryService.GetСoncreteItem(ItemType.Key) > 0)
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("bars_" + Id.ToString(), 1);
            PlayerPrefs.Save();

            _inventoryService.Remove(ItemType.Key, 1);
        }

    }
}

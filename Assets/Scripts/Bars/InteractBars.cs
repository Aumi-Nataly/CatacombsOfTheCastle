using UnityEngine;

public class InteractBars : MonoBehaviour, IInterable
{
    [SerializeField]
    private int Id;

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

    void Start()
    {
        //  Скрыть, если он уже был подобран
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
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("bars_" + Id.ToString(), 1);
        PlayerPrefs.Save();

    }
}

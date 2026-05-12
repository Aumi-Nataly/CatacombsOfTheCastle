using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Health healthPlayer;

    [SerializeField]
    private GameObject HealthText;

    [SerializeField]
    private float Speed;

    private float itogValue;

    private void Start()
    {
        healthPlayer.OnHealthChanged += SetValueHealthUI;
        SetValueHealthUI(healthPlayer.GetCurrent(), healthPlayer.GetMax());
    }

    private void OnDisable()
    {
        healthPlayer.OnHealthChanged -= SetValueHealthUI;
    }

    public void SetValueHealthUI(int current, int max)
    {
        itogValue = (float)current / max;
        HealthText.GetComponent<Text>().text = $"{current.ToString()} / {max.ToString()}";
    }

    void Update()
    {
        image.fillAmount = Mathf.Lerp(image.fillAmount, itogValue, Time.deltaTime * Speed); 
    }
}

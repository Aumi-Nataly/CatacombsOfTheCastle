using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Health healthPlayer;

    [SerializeField]
    private TMP_Text HealthText;


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
        image.fillAmount = (float)current / max;

        HealthText.text = $"{current.ToString()} / {max.ToString()}";

    }
}

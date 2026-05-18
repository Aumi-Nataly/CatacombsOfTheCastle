using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    [SerializeField]
    private Image imageRound;

    [SerializeField]
    private float Speed;

    private void Update()
    {
        imageRound.rectTransform.Rotate(0f, 0f, Speed * Time.deltaTime);


    }
}

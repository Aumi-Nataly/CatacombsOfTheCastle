using System.Timers;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    [SerializeField]
    private float SpeedRotation;

    void Update()
    {
        transform.Rotate(0f, 45.0f * SpeedRotation * Time.deltaTime, 0.0f, Space.Self);
    }
}

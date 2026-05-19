using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 5f);
    }
}

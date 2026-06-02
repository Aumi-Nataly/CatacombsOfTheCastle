using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    void Awake()
    { 
     DontDestroyOnLoad(gameObject);
    }
}

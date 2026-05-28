using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    
    void Start()
    {
        // Устанавливаем целевую частоту кадров
        Application.targetFrameRate = 60;
    }

  
}

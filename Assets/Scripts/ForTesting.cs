using UnityEngine;

public class ForTesting : MonoBehaviour
{
    
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

    }

   
}

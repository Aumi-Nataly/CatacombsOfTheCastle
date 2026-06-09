using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private TMP_Text percentText;

    private void Start()
    {
        StartCoroutine(LoadNextSceneAsync());
    }

    private IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LoaderScene.NextSceneName);

        // Запрет автоматической активации сцены после загрузки
        asyncLoad.allowSceneActivation = false;

        float fakepercent = 0;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            percentText.text = (fakepercent).ToString();

            yield return new WaitForSeconds(0.5f);

            if (asyncLoad.progress >= 0.9f && fakepercent >= 90f)
                asyncLoad.allowSceneActivation = true;

            fakepercent += 10;
        }

        yield return null;
    }
}

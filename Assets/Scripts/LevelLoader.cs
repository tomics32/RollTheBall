using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image loadingBarFill;
    public GameObject fillBar;
    public Text ContinueText;

    Animator anim;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        loadingBarFill.fillAmount = 0;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        LoadingScreen.SetActive(true);

        while(operation.isDone == false)
        {       
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            if (progressValue >= 0.9f)
            {
                fillBar.GetComponent<Animator>().Play("AlphaZero");
                loadingBarFill.GetComponent<Animator>().Play("AlphaZero");
                ContinueText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }   
            }
            yield return null;
        }
    }

}

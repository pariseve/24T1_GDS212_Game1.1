using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement: MonoBehaviour
{
    [SerializeField] private Object sceneObject;
    [SerializeField] private GameObject menuObj;
    
    private Scene currentScene;
    public void GoToScene()
    {
        if (sceneObject != null)
        {
            string sceneName = sceneObject.name;
            if (currentScene.IsValid())
            {
                SceneManager.UnloadSceneAsync(currentScene);
            }
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            currentScene = SceneManager.GetSceneByName(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene Object not assigned.");
        }
    }

    public void OpenPanel()
    {
        menuObj.SetActive(true);
    }


    public void ClosePanel()
    {
        menuObj.SetActive(false);
    }
}

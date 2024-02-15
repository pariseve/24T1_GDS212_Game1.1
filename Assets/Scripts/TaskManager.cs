using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();

    [SerializeField] private GameObject fadePanel;
    [SerializeField]
    private float fadeDuration = 1f;

    public void InitialiseTasks()
    {
        AddTask(new Task("Fix poster", ("Fix poster on the wall")));
        AddTask(new Task("Open Window", "Draw the blinds to let light into the room"));
        AddTask(new Task("Give teddy", "Give the doppo plush to girl"));
        AddTask(new Task("Give drawing", "Give the crumpled drawing to girl"));
        AddTask(new Task("Meow", "announce yourself !"));
    }

    // Add task to task list
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    // Checks if tasks are completed
    public bool AreTasksComplete()
    {
        foreach (Task task in tasks)
        {
            if (!task.IsComplete)
            {
                return false;
            }
        }
        return true;
    }

    // Set task as complete
    public void SetTaskComplete(string taskId)
    {
        Task task = tasks.Find(t => t.id == taskId);
        if (task != null)
        {
            Debug.Log("Task is complete");
            task.MarkComplete();

            // Check if all tasks are complete
            if (AreTasksComplete())
            {
                TriggerEndGame();
            }
        }
    }

    // Trigger end scene
    private void TriggerEndGame()
    {
        StartCoroutine(FadeAndLoad("EndScene"));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        fadePanel.SetActive(true);

        float elapsedTime = 0f;
        Color fadeColor = fadePanel.GetComponent<UnityEngine.UI.Image>().color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeColor.a = alpha;
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        yield return new WaitForSeconds(0.1f); // Wait for a short time to ensure the scene is loaded

        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeColor.a = alpha;
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.SetActive(false);
    }
}


[System.Serializable]
public class Task
{
    public string id;
    public string description;
    [SerializeField] private bool isComplete;

    public Task(string id, string description)
    {
        this.id = id;
        this.description = description;
        this.isComplete = false;
    }

    public bool IsComplete
    {
        get { return isComplete; }
    }

    public void MarkComplete()
    {
        isComplete = true;
    }
}



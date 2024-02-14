using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();

    //add task to task list
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    //checks if tasks are completed
    public bool AreTasksComplete()
    {
        foreach(Task task in tasks)
        {
            if (!task.isComplete)
            {
                return false;
            }
        }
        return true;
    }

    public void TriggerEndGame()
    {
        SceneManager.LoadScene("EndGameScene");
    }
}

[System.Serializable]

public class Task
{
    public string id;
    public string description;
    public bool isComplete { get; private set; }

    public Task(string id, string description)
    {
        this.id = id;
        this.description = description;
        this.isComplete = false;
    }

    public void MarkComplete()
    {
        isComplete = true;
    }
}

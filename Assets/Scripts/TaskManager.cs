using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();

    public void InitialiseTasks()
    {
        AddTask(new Task("Fix poster", ("Fix poster on the wall")));
        AddTask(new Task("Open Window", "Draw the blinds to let light into the room"));
        AddTask(new Task("Give teddy", "Give the doppo plush to girl"));
        AddTask(new Task("Give drawing", "Give the crumpled drawing to girl"));
        AddTask(new Task("Give flowers", "Put the bouquet in the vase"));
    }
    //add task to task list
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    //checks if tasks are completed
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

    public void SetTaskComplete(string taskId)
    {
        Task task = tasks.Find(t => t.id == taskId);
        if (task != null)
        {
            Debug.Log("Task is complete");
            task.MarkComplete();
        }
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


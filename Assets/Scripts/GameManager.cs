using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TaskManager taskManager;

    private void Start()
    {
        Task fixPosterTask = new Task("Fix poster", "fix poster on wall");
        taskManager.AddTask(fixPosterTask);

        Task openWindowTask = new Task("Open window", "Draw the blinds to open the window");
        taskManager.AddTask(openWindowTask);

        Task giveTeddyTask = new Task("Give teddy", "Give the doppo mochi to girl");
        taskManager.AddTask(giveTeddyTask);

        Task giveDrawingTask = new Task("Give drawing", "Give the crumpled drawing to the girl");
        taskManager.AddTask(giveDrawingTask);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TaskManager taskManager;

    private void Start()
    {
        taskManager.InitialiseTasks();
    }
}

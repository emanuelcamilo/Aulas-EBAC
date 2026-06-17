using System.Runtime.CompilerServices;
using UnityEngine;

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed
}


public class TasksList : MonoBehaviour
{

    private TaskStatus currentStatus;

    private void SwitchStatus()
    {
        switch (currentStatus)
        {
            case TaskStatus.NotStarted:
                Debug.Log("Task not started.");
                break;
            case TaskStatus.InProgress:
                Debug.Log("Task in progress.");
                break;
            case TaskStatus.Completed:
                Debug.Log("Task completed.");
                break;
        }
    }

    private void InputKeys()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            currentStatus = TaskStatus.NotStarted;
            SwitchStatus();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            currentStatus = TaskStatus.InProgress;
            SwitchStatus();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            currentStatus = TaskStatus.Completed;
            SwitchStatus();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        InputKeys();

    }
}


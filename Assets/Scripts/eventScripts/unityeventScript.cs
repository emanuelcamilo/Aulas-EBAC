using UnityEngine;
using UnityEngine.Events;

public class unityeventScript : MonoBehaviour
{

    public UnityEvent myEvent;

    public void myDog()
    {
        Debug.Log("May take my dog for a walk");
    }

    public void myCat()
    {
        Debug.Log("Where's my cat?");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            myEvent?.Invoke();
        }
    }
}

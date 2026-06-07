using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int Health = 100;


    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Health -= 10;
            Debug.Log("Health: " + Health);
        }

    }
}

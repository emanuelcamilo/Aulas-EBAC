using System;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    public int Hits = 0;
    public int Damage = 0;


    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hits++;
            Debug.Log("Hits: " + Hits);

            Damage += 10;
            Debug.Log("Damage: " + Damage);
        }
    }
}

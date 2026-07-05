using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public event Action OnPlayerMorreu;

    void Morrer()
    {
        OnPlayerMorreu?.Invoke();
    }   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

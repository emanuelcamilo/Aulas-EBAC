using System;
using UnityEngine;

public class callbackScript : MonoBehaviour
{

    public void DataSave(string saveAtual, Action aoTerminar)
    {
        Debug.Log($"Salvando {saveAtual}...");

        aoTerminar?.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataSave("Save1", () =>
        {
            Debug.Log("Salvamento concluído!");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

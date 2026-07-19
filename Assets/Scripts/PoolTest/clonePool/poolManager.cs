using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

public class poolManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab01;
    public GameObject prefab02;
    public List<GameObject> poolAmarelo;
    public List<GameObject> poolLaranja;
    public List<GameObject> poolVermelho;
    public int poolSize = 2;

    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        poolAmarelo = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            poolAmarelo.Add(obj);
        }

        poolLaranja = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(prefab01, transform);
            obj.SetActive(false);
            poolLaranja.Add(obj);
        }

        poolVermelho = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(prefab02, transform);
            obj.SetActive(false);
            poolVermelho.Add(obj);
        }
    }



    public GameObject GetPoolAmarelo()
    {
        foreach (GameObject obj in poolAmarelo)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        Debug.Log("Pool Amarelo vazio!");
        return null;
    }
    public GameObject GetPoolLaranja()
    {
        foreach (GameObject obj in poolLaranja)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        Debug.Log("Pool Laranja vazio!");
        return null;
    }
    public GameObject GetPoolVermelho()
    {
        foreach (GameObject obj in poolVermelho)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        Debug.Log("Pool Vermelho vazio!");
        return null;
    }


}

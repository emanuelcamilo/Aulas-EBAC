using UnityEngine;
using System.Collections.Generic;

public class Player1 : MonoBehaviour
{
    public List<GameObject> Clone;
    public Transform spawnPoint;
    public Transform spawnPoint01;
    public Transform spawnPoint02;
    public Transform spawnPoint03;
    public poolManager pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnClone();
            Debug.Log("Clone criado!");
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnClones01();
            Debug.Log("Habilidade Clone Duplo Ativada!");
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnClone02();
            Debug.Log("Clone Supremo Invocado!!");
        }
    }

    private void SpawnClone()
    {
        var obj = pool.GetPoolAmarelo();
        if (obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<clonePlayer>().SpawnStart();
            obj.transform.position = spawnPoint.transform.position;
        }


    }

    private void SpawnClones01()
    {
        var obj1 = pool.GetPoolLaranja();
        if (obj1 != null)
        {
            obj1.SetActive(true);
            obj1.GetComponent<clonePlayer>().SpawnStart();
            obj1.transform.position = spawnPoint01.transform.position;
        }

        var obj2 = pool.GetPoolLaranja();
        if (obj2 != null)
        {
            obj2.SetActive(true);
            obj2.GetComponent<clonePlayer>().SpawnStart();
            obj2.transform.position = spawnPoint02.transform.position;
        }

    }

    private void SpawnClone02()
    {
        var obj = pool.GetPoolVermelho();
        if (obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<clonePlayer>().SpawnStart();
            obj.transform.position = spawnPoint03.transform.position;
        }
    }


}

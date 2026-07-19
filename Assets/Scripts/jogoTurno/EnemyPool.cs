using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public GameObject prefabInimigo;
    public CombatManager combatManager;
    public PlayerController player;
    public int tamanhoPool = 3;

    private List<Inimigo> pool = new List<Inimigo>();

    private Vector3[] posicoes =
    {
        new Vector3(-3, 0, 5),
        new Vector3(0, 0, 5),
        new Vector3(3, 0, 5)
    };

    private void Start()
    {
        CriarPool();
        combatManager.InicializarCombate(pool);
    }

    void CriarPool()
    {
        for (int i = 0; i < tamanhoPool; i++)
        {
            GameObject obj = Instantiate(prefabInimigo, posicoes[i], Quaternion.identity, transform);
            obj.name = $"Inimigo_{i + 1}";

            Inimigo inimigo = obj.GetComponent<Inimigo>();
            inimigo.Configurar(this, combatManager);

            pool.Add(inimigo);
        }
    }

    public void DevolverInimigo(Inimigo inimigo)
    {
        inimigo.gameObject.SetActive(false);
        Debug.Log($"{inimigo.name} foi devolvido ao pool.");
    }

    public Inimigo PegarMaisProximo()
    {
        Inimigo maisProximo = null;
        float menorDistancia = Mathf.Infinity;

        foreach (Inimigo inimigo in pool)
        {
            if (!inimigo.gameObject.activeInHierarchy) continue;

            float distancia = Vector3.Distance(player.transform.position, inimigo.transform.position);

            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                maisProximo = inimigo;
            }
        }

        return maisProximo;
    }

}

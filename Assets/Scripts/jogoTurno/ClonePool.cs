using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePool : MonoBehaviour
{
    public GameObject prefabClone;
    public EnemyPool enemyPool;
    public PlayerController player;
    public CombatManager combatManager;
    public int tamanhoPool = 5;

    private List<PlayerClone> pool = new List<PlayerClone>();

    void Start()
    {
        CriarPool();
    }

    void CriarPool()
    {
        for (int i = 0; i < tamanhoPool; i++)
        {
            GameObject obj = Instantiate(prefabClone, transform);
            obj.name = $"Clone_{i + 1}";
            obj.SetActive(false);

            PlayerClone clone = obj.GetComponent<PlayerClone>();
            clone.Configurar(this, enemyPool, player.dano);

            pool.Add(clone);
        }
    }

    public void SpawnarClones(int quantidade)
    {
        StartCoroutine(RotinaClones(quantidade));
    }

    IEnumerator RotinaClones(int quantidade)
    {
        int clonesCriados = 0;

        foreach (PlayerClone clone in pool)
        {
            if (clonesCriados >= quantidade) break;
            if (clone.gameObject.activeInHierarchy) continue;

            Vector3 offset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-1f, 1f));
            clone.transform.position = player.transform.position + offset;
            clone.gameObject.SetActive(true);

            Debug.Log($"[CLONE] {clone.name} foi invocado!");
            StartCoroutine(clone.Atacar());

            clonesCriados++;
            yield return new WaitForSeconds(0.3f);
        }

        if (clonesCriados == 0)
        {
            Debug.Log("[CLONE] Nenhum clone disponível no pool!");
            combatManager.ClonesFinalizaram();
            yield break;
        }

        yield return new WaitForSeconds(1.5f);
        combatManager.ClonesFinalizaram();
    }

    public void DevolverClone(PlayerClone clone)
    {
        clone.gameObject.SetActive(false);
        Debug.Log($"[CLONE] {clone.name} se dissipou.");
        Destroy(clone);
    }

}

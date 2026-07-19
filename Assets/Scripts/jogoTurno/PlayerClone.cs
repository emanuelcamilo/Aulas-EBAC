using System.Collections;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    private ClonePool clonePool;
    private EnemyPool enemyPool;
    private int dano;

    public void Configurar(ClonePool pool, EnemyPool enemies, int danoPlayer)
    {
        clonePool = pool;
        enemyPool = enemies;
        dano = danoPlayer;
    }

    public IEnumerator Atacar()
    {
        yield return new WaitForSeconds(0.5f);

        Inimigo alvo = enemyPool.PegarMaisProximo();

        if (alvo != null)
        {
            Debug.Log($"[Clone] {gameObject.name} atacou {alvo.name} causando {dano} de dano!");
            alvo.ReceberDano(dano);
        }

        else
        {
            Debug.Log($"[CLONE] {gameObject.name} não encontrou nenhum inimigo!");
        }

        yield return new WaitForSeconds(0.5f);
        clonePool.DevolverClone(this);
    }

}

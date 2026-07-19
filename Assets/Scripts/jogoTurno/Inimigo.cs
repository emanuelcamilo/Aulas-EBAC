using UnityEngine;

public class Inimigo : Personagem
{
    private EnemyPool pool;
    private CombatManager combatManager;

    public void Configurar(EnemyPool enemyPool, CombatManager manager)
    {
        pool = enemyPool;
        combatManager = manager;
    }

    public void Atacar(PlayerController player)
    {
        player.ReceberDano(dano);
    }

    protected override void Morrer()
    {
        Debug.Log($"{gameObject.name} foi derrotado!");
        combatManager.InimigoMorreu(this);
        pool.DevolverInimigo(this);
    }

}

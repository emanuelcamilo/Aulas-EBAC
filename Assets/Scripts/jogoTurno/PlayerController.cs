using UnityEngine;

public class PlayerController : Personagem
{
    public CombatManager combatManager;
    public ClonePool clonePool;

    private void Start()
    {
        Debug.Log($"Player pronto - Vida: {vidaAtual} | Dano: {dano}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            combatManager.TentarAtacar();

        if (Input.GetKeyDown(KeyCode.Q))
            combatManager.TentarUsarClones(1);

        if (Input.GetKeyDown(KeyCode.R))
            combatManager.TentarUsarClones(2);
    }

    protected override void Morrer()
    {
        Debug.Log("Player morreu!");
        combatManager.GameOver();
        Destroy(gameObject);
    }

}

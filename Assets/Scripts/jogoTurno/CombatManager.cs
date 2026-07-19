using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using JetBrains.Annotations;

public enum TurnState
{
    PlayerTurn,
    EnemyTurn,
    Vitoria,
    GameOver
}

public class CombatManager : MonoBehaviour
{
    public EnemyPool enemyPool;
    public PlayerController player;
    public ClonePool clonePool;

    private List<Inimigo> inimigos = new List<Inimigo>();
    private TurnState turnoAtual;
    private int inimigosVivos;

    public void InicializarCombate(List<Inimigo> lista)
    {
        inimigos = lista;
        inimigosVivos = lista.Count;
        turnoAtual = TurnState.PlayerTurn;

        Debug.Log("=== Combate Iniciado ===");
        Debug.Log($"Inimigos na cena: {inimigosVivos}");
        Debug.Log("Pressione SPACE para atacar o inimigo mais próximo.");
    }

    public void TentarAtacar()
    {
        if (turnoAtual == TurnState.EnemyTurn)
        {
            Debug.Log("Aguarde o turno do inimigo!");
            return;
        }

        if (turnoAtual != TurnState.PlayerTurn)
        {
            Debug.Log("O combate já terminou!");
            return;
        }

        Inimigo alvo = enemyPool.PegarMaisProximo();
        if (alvo == null) return;

        Debug.Log($"[PLAYER] Atacou {alvo.name}!");
        turnoAtual = TurnState.EnemyTurn;
        alvo.ReceberDano(player.dano);

        if (turnoAtual == TurnState.EnemyTurn)
            StartCoroutine(TurnoInimigo());
    }

    public void TentarUsarClones(int quantidade)
    {
        if (!VerificarTurnoPlayer()) return;

        Debug.Log ($"[PLAYER] Jutsu Clone das Sombras! Invocando {quantidade} clone(s)... ");
        turnoAtual = TurnState.EnemyTurn;
        clonePool.SpawnarClones(quantidade);
    }

    public void ClonesFinalizaram()
    {
        if (turnoAtual == TurnState.EnemyTurn)
            StartCoroutine(TurnoInimigo());
    }

    private bool VerificarTurnoPlayer()
    {
        if (turnoAtual == TurnState.EnemyTurn)
        {
            Debug.Log("Aguarde o turno do inimigo!");
            return false;
        }

        if (turnoAtual != TurnState.PlayerTurn)
        {
            Debug.Log("O combate terminou!");
            return false;
        }

        return true;
    }

    IEnumerator TurnoInimigo()
    {
        Debug.Log("[INIMIGO] Preparando ataque...");
        yield return new WaitForSeconds(1.5f);

        if (turnoAtual != TurnState.EnemyTurn) yield break;

        List<Inimigo> vivos = new List<Inimigo>();
        foreach (Inimigo inimigo in inimigos)
        {
            if (inimigo.gameObject.activeInHierarchy)
                vivos.Add(inimigo);  
        }

        if (vivos.Count > 0)
        {
            Inimigo atacante = vivos[Random.Range(0, vivos.Count)];
            Debug.Log($"[INIMIGO] {atacante.name} atacou o Player!");
            atacante.Atacar(player);
        }

        if (turnoAtual == TurnState.EnemyTurn)
        {
            turnoAtual = TurnState.PlayerTurn;
            Debug.Log("[PLAYER] Seu turno! Pressione SPACE para atacar.");
        }
    }

    public void InimigoMorreu(Inimigo inimigo)
    {
        inimigosVivos--;
        Debug.Log($"Inimigos restantes: {inimigosVivos}");

        if (inimigosVivos <= 0)
            Vitoria();
    }

    void Vitoria()
    {
        turnoAtual = TurnState.Vitoria;
        Debug.Log("=== VITÓRIA! Todos os inimigos foram derrotados!==="); 
    }

    public void GameOver()
    {
        turnoAtual = TurnState.GameOver;
        Debug.Log("=== GAME OVER! ===");
    }

}

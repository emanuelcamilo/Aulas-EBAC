using UnityEngine;

public abstract class Personagem : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int dano = 20;
    protected int vidaAtual;

    protected virtual void Awake()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int quantidade)
    {
        vidaAtual -= quantidade;
        Debug.Log($"{gameObject.name} recebeu {quantidade} de dano. Vida: {vidaAtual}/{vidaMaxima}");

        if (vidaAtual <= 0)
            Morrer();
        
    }

    protected abstract void Morrer();
    public bool EstaVivo() => vidaAtual > 0;

}

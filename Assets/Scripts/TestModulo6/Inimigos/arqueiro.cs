using UnityEngine;

public class arqueiro : MonoBehaviour
{

    public scriptableObjects inimigoDados;

    protected int vidaAtual;
    protected int forcaArma;
    protected string nomeInimigo;

    public void ReceberDano(int forcaArma)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            vidaAtual -= forcaArma;
            Debug.Log("O inimigo " + nomeInimigo + " recebeu " + forcaArma + " de dano.");
        }
    }

    public void Morrer()
    {
        if(vidaAtual <= 0)
        {
            Debug.Log("O inimigo " + nomeInimigo + " morreu.");
            Destroy(gameObject);
        }
    }

    protected virtual void Start()
    {
        vidaAtual = inimigoDados.vidaInimigo;
        forcaArma = inimigoDados.forcaArma;
        nomeInimigo = inimigoDados.nomeInimigo;
    }

    
    void Update()
    {
        ReceberDano(forcaArma);
        Morrer();
    }
}

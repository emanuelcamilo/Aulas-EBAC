using UnityEngine;


public enum TipoInimigo
{
    Arqueiro,
    Goblin,
    Guerreiro
}

public enum TipoArma
{
    Arco,
    Espada,
    Machado,
    Adaga   
}

[CreateAssetMenu]
public class scriptableObjects : ScriptableObject
{

    public string nomeInimigo;
    public int vidaInimigo;
    public int forcaInimigo;
    public string tipoArma;
    public int forcaArma;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.Video;

public class logScript : MonoBehaviour
{

    public Player player;

    public int vida = 100;

    private void OnEnable()
    { 
        player.OnPlayerMorreu += EsconderVida;
    }

    private void OnDisable()
    {
        player.OnPlayerMorreu -= EsconderVida;
    }

    private void EsconderVida()
    {
        Debug.Log("Player morreu, escondendo vida");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

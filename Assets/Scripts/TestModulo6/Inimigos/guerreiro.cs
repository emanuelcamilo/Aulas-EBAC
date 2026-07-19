using UnityEngine;

public class guerreiro : arqueiro
{


    protected override void Start()
    {
        base.Start();
    }


    void Update()
    {
        base.ReceberDano(forcaArma);
        base.Morrer();
    }
}

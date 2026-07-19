using UnityEngine;

public class goblin : arqueiro
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

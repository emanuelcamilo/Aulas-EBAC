using UnityEngine;

public class goblin02 : arqueiro
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

using UnityEngine;
using UnityEngine.Video;



public class InimigoBase : MonoBehaviour
{
    public void Morrer()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Inimigo morreu!");
            Destroy(gameObject);
        }
    }
 
    void Start()
    {
        
    }

    
    void Update()
    {

    }
}

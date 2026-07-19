using UnityEngine;

public class GhostSetup : MonoBehaviour
{
    public GameObject ghost;

    private void Awake()
    {
        ghost.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ghost.SetActive(true);
        Debug.Log("Aparição de fantasma : Susto!!");
    }

    private void OnTriggerExit(Collider other)
    {
        ghost.SetActive(false);
    }

}

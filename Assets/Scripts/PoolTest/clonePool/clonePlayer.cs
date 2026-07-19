using UnityEngine;
using UnityEngine.Rendering;

public class clonePlayer : MonoBehaviour
{
    public float timeToReset = 3f;

    public void SpawnStart()
    {
        Invoke(nameof(ResetSpawn), timeToReset);
    }

    public void ResetSpawn()
    {
        gameObject.SetActive(false);
    }


}

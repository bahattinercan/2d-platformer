using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;
    public GameObject pickupVFX;
    public GameObject deathVFX;
    public GameObject cherry;
    public GameObject gem;
    

    private void Awake()
    {
        instance = this;
    }


}
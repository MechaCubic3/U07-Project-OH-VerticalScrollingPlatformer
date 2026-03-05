using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class Respawn : MonoBehaviour
{
  

    public bool respawnLock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
        onRespawnAllObjects = RespawnAll;
        respawnLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && respawnLock == true)
        {
            Debug.Log("PressedRespawn");

            SceneManager.LoadScene("MainScene");

        }

    }

   

    private void RespawnAll()
    {
        Debug.Log("respawmLockTrue");
        respawnLock = true;
    } 

    
}

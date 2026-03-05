using UnityEngine;
using static GameManager;

public class GetWin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            Debug.Log("Player Touch");
            Winning.Invoke();

        }
    }
}

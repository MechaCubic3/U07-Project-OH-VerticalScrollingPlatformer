using UnityEngine;
using UnityEngine.Tilemaps;
using static GameManager;

public class PillarTileMap : MonoBehaviour
{
    public Tilemap pillar;
    public Tilemap pillarS;
    public Color color;
   
    public float Opas;
    public Collider2D cd2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pillarS.color = color;
        pillar.color = color;
        color.a = Opas;
    }
    private void OnTriggerEnter2D(Collider2D cd2D)
    {


        if (cd2D.CompareTag("Player"))
        {
            Opas = 0.07f;
        }
       


    }

    private void OnTriggerExit2D(Collider2D cd2D)
    {
        if (cd2D.CompareTag("Player"))
        {
            Opas = 1;
            Debug.Log("PillarGraphicOff");
        }
    }

}

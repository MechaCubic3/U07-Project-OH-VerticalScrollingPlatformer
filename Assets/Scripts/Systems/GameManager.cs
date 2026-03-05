using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public delegate void OnPlayerDeath();
    public static OnPlayerDeath onPlayerDeath;

    public delegate void RespawnAllObjects();
    public static RespawnAllObjects onRespawnAllObjects;

    public delegate void TextAct();
    public static RespawnAllObjects textOnAct;

    public delegate void DisablePillar();
    public static RespawnAllObjects pillarOff;

    public delegate void DisableKillingIntent();
    public static RespawnAllObjects killingIntent;

    public delegate void MuseStopWalking();
    public static RespawnAllObjects stopsToLook;

    public delegate void WinningDel();
    public static RespawnAllObjects Winning;

    public delegate void WinningText();
    public static RespawnAllObjects WinText;

    private void Start()
    {
        onPlayerDeath = GameHasEndedFloor;
        Winning = GameWon;
       
    }
    private void Update()
    {
       
    }
    public void GameHasEndedFloor()
    {
        
        Debug.Log("GameEnded");

        Player.SetActive(false);

        onRespawnAllObjects.Invoke();
        textOnAct.Invoke();
        pillarOff.Invoke();
        killingIntent.Invoke();
        stopsToLook.Invoke();
    }

    public void GameWon()
    {
        WinText.Invoke();
        onRespawnAllObjects.Invoke();
    }

}

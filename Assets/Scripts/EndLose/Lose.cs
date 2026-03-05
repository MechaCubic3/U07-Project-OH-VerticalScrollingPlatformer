using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static GameManager;

public class Lose : MonoBehaviour
{

    [SerializeField] private GameObject LoseIcon;

    [SerializeField] private GameObject TryAgain;

    [SerializeField] private GameObject Winn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textOnAct = ActivateText;
        WinText = WinningCral;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateText()
    {
        LoseIcon.gameObject.SetActive(true);
        TryAgain.gameObject.SetActive(true);
        Debug.Log("TextActive");
    }

    private void WinningCral()
    {
        Winn.gameObject.SetActive(true);
    }
}

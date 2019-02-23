using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public int maxLevel;
    public static GameManager main;
    public int starCount;
    public int targetStarCount;

    public Hole holeR;
    public Hole holeL;
    public static int currLevel;

    bool isGameEnded = false;

    void Awake()
    {
        main = this;

        SceneManager.LoadScene(currLevel + 1, LoadSceneMode.Additive);
    }

    public void InreaseStar()
    {
        starCount++;

        CameraShaker.Instance.ShakeOnce(2, 8, 0, 0.6f);
    }

    void Win()
    {
        if (isGameEnded)
            return;

        isGameEnded = true;

        print("WIN");

        currLevel++;

        Camera.main.transform.parent.transform.DOMoveY(12, 1f).SetEase(Ease.OutQuart);

        Invoke("LoadScn", 1);
    }

    void LoadScn()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void LoadWGreat()
    {
        Camera.main.transform.parent.transform.DOMoveY(12, 1f).SetEase(Ease.OutQuart);

        Invoke("LoadScn", 1);
    }

    public void GameOver()
    {
        print("GAME OVER");
    }

    void Start()
    {
        Camera.main.transform.parent.transform.position = new Vector3(0, 12, -10);

        Camera.main.transform.parent.transform.DOMoveY(0, 1f).SetEase(Ease.OutQuart);

        Invoke("Find", 0.01f);
    }

    void Find()
    {
        targetStarCount = FindObjectsOfType<StarController>().Length;

        Hole[] holes = FindObjectsOfType<Hole>();

        holeR = holes[0];

        holeL = holes[1];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadWGreat();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Win();
        }

        if (holeL && holeL.isActivated && holeR.isActivated && starCount >= targetStarCount)
        {
            CameraShaker.Instance.ShakeOnce(3, 8, 0, 1);

            Win();
        }
    }
}

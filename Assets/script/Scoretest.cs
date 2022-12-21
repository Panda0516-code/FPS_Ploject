using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;

public class Scoretest : MonoBehaviour
{
    [SerializeField]
    private float timeleft = default;
    private int seconds;
    [SerializeField]
    Shoot shoot = default;
    [SerializeField]
    private Text Time_text;//スコアのテキスト
    private bool scoreflag = default;
    [SerializeField]
    FPScontoroller fpscontoroller;
    private void Start()
    {
        TimeChecker();
        
    }
    private void Update()
    {
        
         timeleft = timeleft - Time.deltaTime;
        seconds = (int)timeleft;
        Time_text.text = seconds.ToString() + "秒";
        if (seconds <= 0 && !scoreflag) {
            Cursor.lockState = CursorLockMode.None;
            fpscontoroller.enabled = false;
            Debug.Log("ああああああ");
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(shoot.player_score_cnt);
            Time.timeScale = 0;
            shoot.enabled = false;
            scoreflag = true;
        }

    }
    private void TimeChecker()
    {
        if (timeleft <= 0)
        {
            Debug.Log("設定した時間がマイナスか０だバカ！！！");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif 
        }
    }

}

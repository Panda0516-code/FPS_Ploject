using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;

public class Scoretest : MonoBehaviour
{
    [SerializeField]
    private float timeleft = default;//制限時間
    private int seconds;//残り時間の変数
    [SerializeField]
    Shoot shoot = default;//シュートスクリプト
    [SerializeField]
    private Text Time_text;//スコアのテキスト
    private bool scoreflag = default;
    [SerializeField]
    FPScontoroller fpscontoroller;//視点移動のスクリプト
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

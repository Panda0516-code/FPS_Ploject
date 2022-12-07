using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class Scoretest : MonoBehaviour
{
    [SerializeField]
    private float timeleft = default;

    private void Start()
    {
        TimeChecker();
    }
    private void Update()
    {
        while (timeleft > 0) 
        { timeleft = timeleft - Time.time; }
        
        
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

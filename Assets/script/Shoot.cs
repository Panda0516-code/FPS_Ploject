using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject Camera;//メインのカメラ
    [SerializeField]
    private int maxcount = default;//敵の最大数
    private int hitcount =default;//for文で回すときに何回回したかカウントする変数
    private int active = default;//アクティブか判定したときに増減させる、判定用の変数
    private GameObject[] hitobj;//敵を格納する配列
    RaycastHit hit;//当たった判定を格納する
    private void Start()
    {
        hitobj = GameObject.FindGameObjectsWithTag("Enemy");//配列内に敵のタグがついたオブジェクトを格納
        
        int[] ary = Enumerable.Range(0, hitobj.Length).OrderBy(n => Guid.NewGuid()).Take(hitobj.Length).ToArray();//hitobj内の順番をランダムにする
        
        foreach (GameObject enemy in hitobj) { enemy.SetActive(false); }//読み込んだあとは全部の敵をfalseにする
        
        for (hitcount = 0; hitcount < maxcount; hitcount++)//敵を出すfor文、hitcountがmaxcountを上回ったら抜ける
        {
            hitobj[ary[hitcount]].SetActive(true);//配列内の敵をtrueにしている   
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//マウスの左クリック
        {
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 1000f))//画面の中心からrayを飛ばす
            {  
                if (hit.collider.tag == "Enemy")//敵のタグがついたものに当たったら
                {
                    hit.collider.gameObject.SetActive(false);//当たったやつをfalseに
                    RandomReEnemyAppear();//ランダムなほかのやつをtrueにする
                }
            }
        }
    }
    private void RandomReEnemyAppear()//ランダムにtrueにするクラス
    {
        int[] ary = Enumerable.Range(0, hitobj.Length).OrderBy(n => Guid.NewGuid()).Take(hitobj.Length).ToArray();//hitobj内の順番をランダムにする
            while(hitobj[ary[active]].activeSelf == true)//ランダムに指定した箇所がアクティブだった時に
        {
            active++;//判定箇所をずらしてもう一度判定する
        }
        hitobj[ary[active]].SetActive(true);//配列内の敵をtrueにしている
        active = 0;//判定箇所のリセット
    }
   
}

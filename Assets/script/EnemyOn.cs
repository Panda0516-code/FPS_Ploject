using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class EnemyOn : MonoBehaviour
{
    private int maxcount = default;//敵の最大数
    private int hitcount = default;//for文で回すときに何回回したかカウントする変数
    private int active = default;//アクティブか判定したときに増減させる、判定用の変数
    private GameObject[] hitobj;//敵を格納する配列
    void Start()
    {
        hitobj = GameObject.FindGameObjectsWithTag("Enemy");//配列内に敵のタグがついたオブジェクトを格納

        int[] ary = Enumerable.Range(0, hitobj.Length).OrderBy(n => Guid.NewGuid()).Take(hitobj.Length).ToArray();//hitobj内の順番をランダムにする

        foreach (GameObject enemy in hitobj) { enemy.SetActive(false); }//読み込んだあとは全部の敵をfalseにする

        for (hitcount = 0; hitcount < maxcount; hitcount++)//敵を出すfor文、hitcountがmaxcountを上回ったら抜ける
        {
            hitobj[ary[hitcount]].SetActive(true);//配列内の敵をtrueにしている
        }
    }

    private void RandomReEnemyAppear()//ランダムにtrueにするメソッド
    {
        int[] ary = Enumerable.Range(0, hitobj.Length).OrderBy(n => Guid.NewGuid()).Take(hitobj.Length).ToArray();//hitobj内の順番をランダムにする
        while (hitobj[ary[active]].activeSelf == true)//ランダムに指定した箇所がアクティブだった時に
        {
            active++;//判定箇所をずらしてもう一度判定する
        }
        hitobj[ary[active]].SetActive(true);//配列内の敵をtrueにしている
        active = 0;//判定箇所のリセット
    }
}

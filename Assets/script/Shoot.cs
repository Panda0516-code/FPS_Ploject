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
    GameObject parent;
    [SerializeField]
    private int takeobj = default;
    RaycastHit hit;//当たった判定を格納する
    private GameObject[] hitobj;
    private int[] ary;
    private int hitcount =default;
    [SerializeField]
    private int maxcount = default;
    private void Start()
    {
        hitobj = GameObject.FindGameObjectsWithTag("Enemy");
        int[] ary = Enumerable.Range(0, hitobj.Length).OrderBy(n => Guid.NewGuid()).Take(takeobj).ToArray();
        foreach (GameObject ball in hitobj)
        {
            ball.SetActive(false);
        }

    }
    private void Update()
    {
        

        for (hitcount = 0; hitcount <= maxcount; hitcount++)
        {
            
            hitobj[ary[hitcount]].SetActive(true);
        }
       
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 1000f))//画面の中心からrayを飛ばす
            {
                
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.SetActive(false);
                    //hitobj[hitcount] = hit.collider.gameObject;
                    hitcount--;
                    
                    
                    
                }

            }
        }
        
    }
    IEnumerator EnemyAppear()
    {
        foreach (GameObject enemy in hitobj) {
            yield return new WaitForSeconds(2.0f);
            
        }
            
        
        
    }
}

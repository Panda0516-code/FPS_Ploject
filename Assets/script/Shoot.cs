using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject Camera;//メインのカメラ
    RaycastHit hit;//当たった判定を格納する
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 1000f))//画面の中心からrayを飛ばす
            {
                
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.SetActive(false);
                    StartCoroutine("CubeAppear");
                }

            }
        }
        
    }
    IEnumerator CubeAppear()
    {
        yield return new WaitForSeconds(2.0f);
        hit.collider.gameObject.SetActive(true);
    }
}

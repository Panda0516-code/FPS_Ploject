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
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 1000f))//画面の中心からrayを飛ばす
            {
                if (hit.collider.tag == "")
                {
                    hit.collider.gameObject.SetActive(false);
                }


            }
        }
        
    }
}

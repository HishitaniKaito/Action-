using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float jump = 3;
    public float Moves = 2;
    [SerializeField] Rigidbody Rb;
    [SerializeField]int Hp = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Ppos = this.transform.position;//プレイヤーの位置
        Vector3 direction = new Vector3(0, -1, 0);//Y軸方向表すベクトル
        Ray ray = new Ray(Ppos, direction);//地面を感知するrayの生成
        Debug.DrawRay(Ppos,direction,Color.black,0.1f,false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(Vector3.up *jump,ForceMode.Impulse);//飛ぶ動作
            Debug.Log("Jump");
        }
        //左右への移動
        if(Input.GetKey(KeyCode.A))
        {
            Rb.AddForce(Vector3.right * (Moves * -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rb.AddForce(Vector3.right * Moves);
        }
        RaycastHit hit;
        if(Input.GetKey(KeyCode.S))
        {
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("rayは機能している");
                
                if (hit.collider.gameObject.name == "MoteruJimen")
                {
                    Debug.Log("持てるやつ感知");
                }
            }
            
        }

    }
    public void worp(Vector3 wpos)
    {
        this.gameObject.transform.position = wpos;
    }

}

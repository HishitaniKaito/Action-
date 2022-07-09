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
        Vector3 Ppos = this.transform.position;//�v���C���[�̈ʒu
        Vector3 direction = new Vector3(0, -1, 0);//Y�������\���x�N�g��
        Ray ray = new Ray(Ppos, direction);//�n�ʂ����m����ray�̐���
        Debug.DrawRay(Ppos,direction,Color.black,0.1f,false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(Vector3.up *jump,ForceMode.Impulse);//��ԓ���
            Debug.Log("Jump");
        }
        //���E�ւ̈ړ�
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
                Debug.Log("ray�͋@�\���Ă���");
                
                if (hit.collider.gameObject.name == "MoteruJimen")
                {
                    Debug.Log("���Ă����m");
                }
            }
            
        }

    }
    public void worp(Vector3 wpos)
    {
        this.gameObject.transform.position = wpos;
    }

}

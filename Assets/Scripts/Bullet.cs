using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power = 30.0f;
    public float distance = 20.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * power;
        // �Ѿ��� ���� �Ÿ� �̻� �������� �� �ı��ϱ�
        //if (transform.position.magnitude > distance)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().zombieHp -= 2;
        }
        Destroy(gameObject);
    }

}

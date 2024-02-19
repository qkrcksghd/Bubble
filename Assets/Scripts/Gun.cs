using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform m_Transform;
    public float m_moveSpeed;
    public float m_RotationSpeed;
    public Rigidbody m_Rigidbody;
    public Transform m_Muzzle;
    public GameObject m_Bubble;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = m_Transform.position;
        Vector3 Rotation = m_Transform.rotation.eulerAngles;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(m_Bubble, m_Muzzle.position, m_Muzzle.rotation);

            Destroy(obj, 2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject btnBoom;
    public GameObject btnShoot;
    public GameObject freeZombieObject;
    public Zombie zombieScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject freeZombieObject = GameObject.Find("FreeZombieSimpleMovement"); // ��ü�� �̸����� ã�� �Ǵ� �ٸ� ������� ��������
        zombieScript = freeZombieObject.GetComponent<Zombie>(); // Zombie ��ũ��Ʈ ��������
        btnBoom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bubble")
        {
            btnBoom.SetActive(true);
            btnShoot.SetActive(false);
            zombieScript.boom = 1;
        }
    }
}

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
        GameObject freeZombieObject = GameObject.Find("FreeZombieSimpleMovement"); // 객체의 이름으로 찾기 또는 다른 방법으로 가져오기
        zombieScript = freeZombieObject.GetComponent<Zombie>(); // Zombie 스크립트 가져오기
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

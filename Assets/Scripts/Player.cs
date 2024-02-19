using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Vector2 inputDirection;
    [SerializeField]
    private Rigidbody rigid;
    public int JumpPower;
    private bool isMove;
    private bool isRotation;
    public float speed;
    private bool isJump = false;
    public bool getWeapon = false;
    public float lookSensitivity = 0;
    private int shootCount;
    public Animator animator;
    public GameObject bulletPos;
    public GameObject bullet;
    public int HP=10;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        gun.SetActive(false);
        rigid = GetComponent<Rigidbody>();
        animator.SetBool("isMove", false);
        shootCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move(inputDirection);
        if(HP < 0)
        {
            Debug.Log("¡◊¿Ω");
        }
    }
    public void IsJump()
    {
        if (isJump == true)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = false;
        }

    }
    public void GetWeapon()
    {
        getWeapon = !getWeapon;
        animator.SetBool("getWeapon", getWeapon);
        if(getWeapon == true) gun.SetActive(true);
        else gun.SetActive(false);
    }
    public void IsShoot()
    {

        if (getWeapon == true)
        {  
            
            if (animator.GetBool("isShoot") == false)
            {
                animator.SetBool("isShoot", true);
                Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
                Invoke("ShootSetting", 1f);
                shootCount += 1;
                Invoke("LoadTrueSetting", 0.5f);
            }
        }
    }

    private void ShootSetting()
    {
        animator.SetBool("isShoot", false);

    }

    private void LoadTrueSetting()
    {
        if (shootCount > 4)
        {

            Debug.Log("¿Â¿¸");
            animator.SetBool("isLoad", true);
            Invoke("LoadFalseSetting", 1f);
            shootCount = 0;

        }
    }
    private void LoadFalseSetting()
    {
        animator.SetBool("isLoad", false);
    }
    public void Move(Vector2 inputDirection)
    {
        isMove = inputDirection.magnitude != 0;
        Vector3 _moveHoizontal = transform.right * inputDirection.y;
        Vector3 _moveVertial = transform.forward * -inputDirection.x;
        Vector3 move = (_moveVertial + _moveHoizontal).normalized * speed;
        if (isMove)
        {
            transform.position += move * Time.deltaTime * speed;
            float _yRotation = inputDirection.x;
            Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(_characterRotationY));
            Debug.Log(_characterRotationY);
        }

        transform.position += move * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJump = true;
    }
    
}

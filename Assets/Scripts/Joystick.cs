using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Ű����, ���콺, ��ġ�� �̺�Ʈ�� ������Ʈ�� ���� �� �ִ� ����� ����

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)]
    private float leverRange;
    [SerializeField]
    private Player controller;
    private Vector2 inputDirection;
    private bool isInput;    // �߰�
    public Animator animator;
    public GameObject player; 
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos
            : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
        isInput = true;    // �߰�
    }
    public void OnDrag(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos
            : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;    // �߰�
        inputDirection = Vector2.zero;
        controller.Move(Vector2.zero);
    }
    
    void Update()
    {
        //Debug.Log(inputDirection);
        if (isInput)
        {
            controller.Move(inputDirection);
            if (player.GetComponent<Player>().getWeapon == true)
            {
                animator.SetBool("ww", true);
            }
            else animator.SetBool("isMove", true);
        }
        else 
        { 
            animator.SetBool("isMove", false);
            animator.SetBool("ww", false);
        }
    }


}
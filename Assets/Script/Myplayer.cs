using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField]//�ν����Ϳ����� ���� �����ϰ�
    private float smoothRotationTime;//target ������ ȸ���ϴµ� �ɸ��� �ð�
    [SerializeField]
    private float smoothMoveTime;//target �ӵ��� �ٲ�µ� �ɸ��� �ð�
    [SerializeField]
    private float moveSpeed;//�����̴� �ӵ�
    [SerializeField]
    float jumpPower = 1f;
    private float rotationVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float speedVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float currentSpeed;
    private float targetSpeed;
    public DynamicJoystick joystick;
    private Transform cameraTransform;
    
    Rigidbody rb;
    Animator animator;
    Vector2 input;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
        cameraTransform = Camera.main.transform;
    }
    void Update()
    {

        input =Vector2.zero;
        input = new Vector2(joystick.input.x,joystick.input.y);
        //GetAxisRaw("Horizontal") :������ ����Ű������ 1�� ��ȯ, �ƹ��͵� �ȴ����� 0, ���ʹ���Ű�� -1 ��ȯ
        //GetAxis("Horizontal"):-1�� 1 ������ �Ǽ����� ��ȯ
        //Vertical�� ���ʹ���Ű ������ 1,�ƹ��͵� �ȴ����� 0, �Ʒ��ʹ���Ű�� -1 ��ȯ

        Vector2 inputDir = input.normalized;
        //���� ����ȭ. ���� input=new Vector2(1,1) �̸� �������� �밢������ �����δ�.
        //������ ã���ش�

        if (inputDir != Vector2.zero)//�������� ������ �� �ٽ� ó�� ������ ���ư��°� ��������
        {
            
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref rotationVelocity, smoothRotationTime);
        }
        //������ �����ִ� �ڵ�, �÷��̾ ������ �� �밢������ �����Ͻ� �� ������ �ٶ󺸰� ���ش�
        //Mathf.Atan2�� ������ return�ϱ⿡ �ٽ� ������ �ٲ��ִ� Mathf.Rad2Deg�� �����ش�
        //Vector.up�� y axis�� �ǹ��Ѵ�
        //SmoothDampAngle�� �̿��ؼ� �ε巴�� �÷��̾��� ������ �ٲ��ش�.

        targetSpeed = moveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, smoothMoveTime);
        //���罺�ǵ忡�� Ÿ�ٽ��ǵ���� smoothMoveTime ���� ���Ѵ�
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
    }
    private void LateUpdate()
    {
        if (input != Vector2.zero)
        {
            animator.SetBool("isWalk", true);
        }
        else {
            animator.SetBool("isWalk", false);
        }
    }
    public void Jump()
    {
       
        rb.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
      
    }

}
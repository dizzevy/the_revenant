using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //------------------------������������ ���������--------------------------//


    public CharacterController controller; //������ �� ���������� ���������
    public float speed; // �������� ���������
    public float walkSpeed; //�������� ��� ������
    public float runSpeed; //�������� ��� ����
    public float normaHeight; //������������ ������ ���������
    public float sitHeight; //������ ��������� � �������


    //-----------------------------����������---------------------------------//

    public Transform groundCheck; // ������ �� groundCheck 
    public float groundCheckDistance; // ������ ����� groundCheck
    public float gravity = -19f; // ����������
    Vector3 velocity; //������ ���������� �� �������� �������
    bool isGrounded; //�������� �� �����]
    public LayerMask groundMask;

    //-------------------------------������-----------------------------------// 

    public float jumpHeight = 1f;

    void Update()
    {
        //------------------------������������ ���������--------------------------//
        float x = Input.GetAxis("Horizontal"); //���������� �� ��������� w/s
        float z = Input.GetAxis("Vertical"); //���������� �� ��������� a/d
        Vector3 move = transform.right * x + transform.forward * z; // ��������� ��� Vector3 movev �� ���� ������������
        controller.Move(move * speed * Time.deltaTime); // ������� �����

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = sitHeight;
        }
        else
        {
            controller.height = normaHeight;
        }


        //-----------------------------����������---------------------------------//
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime; // ��������� ��� ���������� �� ���� ������������
        controller.Move(velocity * Time.deltaTime); // ��������� ��� ��������� ����������

        //-------------------------------������-----------------------------------// 

        if(isGrounded && (Input.GetButtonDown("Jump"))) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
     
    }
}

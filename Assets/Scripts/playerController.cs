using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //------------------------передвижение персонажа--------------------------//


    public CharacterController controller; //ссылка на контроллер персонажа
    public float speed; // скорость персонажа
    public float walkSpeed; //скорость при ходьбе
    public float runSpeed; //скорость при беге
    public float normaHeight; //обыкновенная высота персонажа
    public float sitHeight; //высота персонажа в приседе


    //-----------------------------гравитация---------------------------------//

    public Transform groundCheck; // ссылка на groundCheck 
    public float groundCheckDistance; // радиус сферы groundCheck
    public float gravity = -19f; // гравитация
    Vector3 velocity; //вектор отвечающий за скорость падения
    bool isGrounded; //проверка на землю]
    public LayerMask groundMask;

    //-------------------------------прыжок-----------------------------------// 

    public float jumpHeight = 1f;

    void Update()
    {
        //------------------------передвижение персонажа--------------------------//
        float x = Input.GetAxis("Horizontal"); //переменная со значением w/s
        float z = Input.GetAxis("Vertical"); //переменная со значением a/d
        Vector3 move = transform.right * x + transform.forward * z; // указываем что Vector3 movev из себя представляет
        controller.Move(move * speed * Time.deltaTime); // двигаем перса

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


        //-----------------------------гравитация---------------------------------//
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime; // указываем что гравитация из себя представляет
        controller.Move(velocity * Time.deltaTime); // дабавляем для персонажа гравитацию

        //-------------------------------прыжок-----------------------------------// 

        if(isGrounded && (Input.GetButtonDown("Jump"))) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
     
    }
}

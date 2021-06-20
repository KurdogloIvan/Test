using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float speedMove;
    public float jumpPower;
    public float gravitationForce;
    private float rotateSpeed = 4f;
    private float gravityForce;

    public Collider Sword;
    public Collider Hammer;

    private Vector3 moveVector = Vector3.zero;

    private CharacterController ch_character;
    public Animator ch_animator;

    private WeaponScript _weapon;

    void Start()
    {
        ch_character = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        _weapon = GameObject.FindObjectOfType<WeaponScript>();

    }

    void Update()
    {
        CharacterController();
        GamingGravity();
        WeaponAttack();
    }

    public void CharacterController()
    {
        if (ch_character.isGrounded)
        {
            ch_animator.ResetTrigger("Jump");
        }

        moveVector = new Vector3(0, 0, Input.GetAxis("Vertical"));

        moveVector = transform.TransformDirection(moveVector);
        moveVector *= speedMove;
        //Анимация
        if (Input.GetAxis("Vertical") > 0) ch_animator.SetBool("Walk", true);    
        else ch_animator.SetBool("Walk", false);


        if (Input.GetAxis("Vertical") < 0) ch_animator.SetBool("Walk Back", true);
        else ch_animator.SetBool("Walk Back", false);
        //Поворот вокруг оси
        if (Vector3.Angle(Vector3.down, moveVector) > 0.1f || Vector3.Angle(Vector3.down, moveVector) == 0)
        {
            transform.Rotate(Vector3.down * rotateSpeed * Input.GetAxis("Horizontal") * -1, Space.World);
        }
        moveVector.y = gravityForce;
        ch_character.Move(moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!ch_character.isGrounded) gravityForce -= gravitationForce * Time.deltaTime;
        else gravityForce = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_character.isGrounded)
        {
            gravitationForce = jumpPower;
            ch_animator.SetTrigger("Jump");
        }

    }
    public void WeaponAttack()
    {
        int index = _weapon.WeaponIndex;
        if (Input.GetMouseButtonDown(0))
        {
            if(index == 0)
            {
                ch_animator.SetTrigger("Attack");
            }
            else
            {
                ch_animator.SetTrigger("HammerAttack");
            }
        }
    }
}

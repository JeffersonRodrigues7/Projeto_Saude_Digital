using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public MovementJoystick joystickMovement;
    public float speed = 3.0f;
    private Rigidbody2D rb;

    [SerializeField] Animator animator = null;
    private Vector2 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(joystickMovement.joystickVec);
        bool walking = false;
        Vector2 move = new Vector2(joystickMovement.joystickVec.x, joystickMovement.joystickVec.y);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            walking = true;
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("xDirection", lookDirection.x);
        animator.SetFloat("yDirection", lookDirection.y);
        animator.SetBool("isWalking", walking);
    }

    void FixedUpdate()
    {

        Vector2 position = rb.position;
        position.x = position.x + speed * joystickMovement.joystickVec.x * Time.deltaTime;
        position.y = position.y + speed * joystickMovement.joystickVec.x * Time.deltaTime;

        rb.MovePosition(position);

    }
}

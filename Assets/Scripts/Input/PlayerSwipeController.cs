using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerSwipeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] Animator animator = null;
    public MovementJoystick joystickMovement;

    private Rigidbody2D rigidbody2d = null;
    private Vector3 playerVelocity;
    private bool consumedSwipe = false;
    private bool isInDialogue = false;
    private bool isInCutscene = false;
    private bool movementBlocked = false;
    private Vector2 lookDirection;

    Vector2 moveT;
    float horizontal;
    float vertical;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SwipeDetector.OnSwipe += ProcessMovement;
    }

    private void OnDestroy()
    {
        SwipeDetector.OnSwipe -= ProcessMovement;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;

        }
        else
        {
            horizontal = 0;
        }

        ProcessMovement(horizontal, vertical);
    }


    private void FixedUpdate()
    {
        if (isInDialogue || isInCutscene || movementBlocked)
        {
            rigidbody2d.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        //consumedSwipe = true;

        if (consumedSwipe)
        {
            rigidbody2d.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);

        }

        else
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + moveSpeed * joystickMovement.joystickVec.x * Time.deltaTime;
            position.y = position.y + moveSpeed * joystickMovement.joystickVec.y * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }


        //Vector2 position = rigidbody2d.position;
        //position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
        //position.y = position.y + moveSpeed * vertical * Time.deltaTime;

        //rigidbody2d.MovePosition(position);



    }

    public void SetInDialogue(bool inDialogue)
    {
        isInDialogue = inDialogue;
    }

    public void SetInCutscene(bool InCutscene)
    {
        isInCutscene = InCutscene;
    }

    public void BlockMovement()
    {
        movementBlocked = true;
    }

    public void UnblockMovement()
    {
        movementBlocked = false;
    }

    private void ProcessMovement(SwipeData swipeData)
    {
        if (isInDialogue || isInCutscene || movementBlocked)
        {
            return;
        }

        consumedSwipe = false;

        //Debug.Log("here");

        Vector2 move = new Vector2(joystickMovement.joystickVec.x, joystickMovement.joystickVec.y);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        bool isWalking = (Mathf.Abs(lookDirection.x) > 0.0f || Mathf.Abs(lookDirection.y) > 0.0f);

        animator.SetFloat("xDirection", lookDirection.x);
        animator.SetFloat("yDirection", lookDirection.y);
        animator.SetBool("isWalking", isWalking);
    }

    private void ProcessMovement(float horizontal, float vertical)
    {
        if (isInDialogue || isInCutscene || movementBlocked)
        {
            return;
        }




        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        else if (!Mathf.Approximately(moveT.x, 0.0f) || !Mathf.Approximately(moveT.y, 0.0f))
        {
            lookDirection.Set(moveT.x, moveT.y);
            lookDirection.Normalize();
        }

        bool isWalking = (Mathf.Abs(lookDirection.x) > 0.0f || Mathf.Abs(lookDirection.y) > 0.0f);

        animator.SetFloat("xDirection", lookDirection.x);
        animator.SetFloat("yDirection", lookDirection.y);
        animator.SetBool("isWalking", isWalking);

    }


}

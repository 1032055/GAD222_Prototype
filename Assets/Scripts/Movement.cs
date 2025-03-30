using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Movement Script Control for Prototype 1
/// 
/// Made with the help of tutorial "FIRST PERSON MOVEMENT in Unity 3D - New Input System" by Driple Studios
/// https://www.youtube.com/watch?v=Tz-2Z0vLLt8
/// </summary>

public class MovementControl : MonoBehaviour
{
    //Variables
    [SerializeField] protected int speed;
    public bool interacting;

    protected Vector2 moveDir;
    protected Rigidbody2D playerRB;

    [SerializeField] private GameObject thunkImg;

    // Start is called before the first frame update
    void Start()
    {
        if (playerRB == null)
        {
            playerRB = GetComponent<Rigidbody2D>();
            //Debug.Log(playerRB);
        }
        interacting = false;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void OnMove(InputValue dir)
    {
        //Debug.Log("Input Detected");
        moveDir = dir.Get<Vector2>();
    }

    protected virtual void Moving()
    {
        Vector2 playerMoving = new Vector2(moveDir.x * speed, moveDir.y * speed);
        playerRB.velocity = transform.TransformDirection(playerMoving);
        //Debug.Log("move our boy in that way" + playerMoving);
    }

    void OnInteract()
    {
        Debug.Log("interaction occurs");
        interacting = !interacting;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //show lil thunk noise
        thunkImg.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5;
    private float MoveVertical = 0;
    private float MoveHorizontal = 0;
    private Rigidbody2D rb2d;
    public float Health { get; set; }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        KeyCode RightKey = KeyCode.D; //shortcut
        KeyCode LeftKey = KeyCode.A; //shortcut
        if (Input.GetKey(RightKey)) //when Right Key pressed (D)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        }
        else if (Input.GetKey(LeftKey)) //when Left Key pressed (A)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left);
        }
    }
}

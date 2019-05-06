using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float health = 100;
    public int points = 0;
    public int[] pointsType = { 0, 0, 0, 0, 0 };
    private Animator animator;
    private Rigidbody2D Rigidbody;
    private AudioSource pointGotten;
    private Transform Direction;
    private float Speed = 15f;
    private float Move;
    private int direction;
    public string expectedTag;
    public UnityEngine.UI.Text Statistics;
    public GameObject Canvas;
    public UnityEngine.UI.Text TrashType;
    public UnityEngine.UI.Text Plasticos;
    public UnityEngine.UI.Text Organicos;
    public UnityEngine.UI.Text Ordinarios;
    public UnityEngine.UI.Text Metales;
    public UnityEngine.UI.Text Papel;
    private string[] tags = { "Plasticos", "Organicos", "Ordinarios", "Metales", "Papel" };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Direction = GetComponent<Transform>();
        pointGotten = GetComponent<AudioSource>();
        InvokeRepeating("RandomTag", 0f, 30f);
    }
    void RandomTag()
    {
        int pos = Random.Range(0, tags.Length);
        expectedTag = tags[pos];
        TrashType.text = tags[pos];
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction.rotation.y != 0)
            Direction.Rotate(Vector3.up, 180);
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Direction.rotation.y != -180)
            Direction.Rotate(Vector3.up, 180);
        if (Move != 0)
            animator.Play("PlayerMoving");
        else
            animator.Play("PlayerAnimation");
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(Move, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        Rigidbody.velocity = movement * Speed;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == expectedTag)
        {
            switch (expectedTag)
            {
                case "Plasticos":
                    pointsType[0] += 10;
                    break;
                case "Metales":
                    pointsType[1] += 10;
                    break;
                case "Organicos":
                    pointsType[2] += 10;
                    break;
                case "Ordinarios":
                    pointsType[3] += 10;
                    break;
                case "Papel":
                    pointsType[4] += 10;
                    break;
            }
            points += 10;
            Statistics.text = points.ToString();
            Plasticos.text = pointsType[0].ToString();
            Metales.text = pointsType[1].ToString();
            Organicos.text = pointsType[2].ToString();
            Ordinarios.text = pointsType[3].ToString();
            Papel.text = pointsType[4].ToString();
            pointGotten.Play();
        }
        else
        {
            DeacreasePoints();
        }
    }
    public void DeacreasePoints()
    {
        points -= 5;
        Statistics.text = points.ToString();
    }
}
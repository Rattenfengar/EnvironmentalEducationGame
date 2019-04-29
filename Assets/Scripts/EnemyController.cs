using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float FallingSpeed = -10f;
    private Rigidbody2D Rigidbody;
    private SpriteRenderer icon;
    public Sprite[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        icon = GetComponent<SpriteRenderer>();
        icon.sprite = Sprites[Random.Range(0, 13)];
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody.velocity = new Vector2(0, FallingSpeed);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}

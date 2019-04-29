using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float FallingSpeed = -10f;
    private Rigidbody2D Rigidbody;
    private SpriteRenderer icon;
    public Sprite[] SpritesPlastic;
    public Sprite[] SpriteOrganic;
    public Sprite[] SpriteOrdinary;
    public Sprite[] SpriteMetals;
    public Sprite[] SpritePaper;
    private string[] tags = { "Plasticos", "Organicos", "Ordinarios", "Metales", "Papel" };
    // Start is called before the first frame update
    void Start()
    {
        int pos = Random.Range(0, tags.Length);
        this.tag = tags[pos];
        Rigidbody = GetComponent<Rigidbody2D>();
        icon = GetComponent<SpriteRenderer>();
        switch (pos)
        {
            case 0:
                icon.sprite = SpritesPlastic[Random.Range(0, SpritesPlastic.Length)];
                break;
            case 1:
                icon.sprite = SpriteOrganic[Random.Range(0, SpriteOrganic.Length)];
                break;
            case 2:
                icon.sprite = SpriteOrdinary[Random.Range(0, SpriteOrdinary.Length)];
                break;
            case 3:
                icon.sprite = SpriteMetals[Random.Range(0, SpriteMetals.Length)];
                break;
            case 4:
                icon.sprite = SpritePaper[Random.Range(0, SpritePaper.Length)];
                break;
        }
        
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

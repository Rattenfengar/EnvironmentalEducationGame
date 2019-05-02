using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlafomController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public UnityEngine.UI.Text CurrentTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(CurrentTag.text))
        {
            Player.SendMessage("DeacreasePoints");
        }
    }
}

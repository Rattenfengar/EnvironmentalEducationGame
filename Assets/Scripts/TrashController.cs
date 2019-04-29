using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    private UnityEngine.UI.Text Trash;
    // Start is called before the first frame update
    void Start()
    {
        Trash = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTrash(string name)
    {
        Trash.text = name;
    }
}

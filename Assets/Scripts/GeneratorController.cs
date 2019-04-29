using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject Trash;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateTrash()
    {
        var position = new Vector2(Random.Range(-11,11), 11);
        Instantiate(Trash, position, Quaternion.identity);
    }
    public void StartGenerator()
    {
        InvokeRepeating("GenerateTrash", 1f, 1f);
    }
    public void StopGenerator()
    {
        CancelInvoke("GenerateTrash");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private UnityEngine.UI.Text Points;
    private int points=0;
    // Start is called before the first frame update
    void Start()
    {
        Points = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreasePoints()
    {
        points += 10;
        Points.text = points.ToString();
    }
    public void DecreasePoints()
    {
        points -= 5;
        Points.text = points.ToString();
    }
}

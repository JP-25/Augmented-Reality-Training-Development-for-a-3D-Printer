using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulate_Scale : MonoBehaviour
{
    GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.Find("Cube");
    }
    public Vector3 localScale;
    public float x = 0.1f;
    public float y = 0.1f;
    public float z = 0.1f;
    public void Increase()
    {
        test.gameObject.transform.localScale += new Vector3(x,y,z);
    }
    // Update is called once per frame
    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f; public Material mat;
    private Vector2 offset = Vector2.zero;

    private Transform knight;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        knight = GameObject.Find("Knight").transform;
    }
    void Start() {

        offset = mat.GetTextureOffset("_MainTex"); 
    }
    // Update is called once per frame
    void Update () {
        Vector2 offset = new Vector2(knight.position.x * speed, 0); 
       GetComponent<Renderer>().material.mainTextureOffset = offset;
        mat.SetTextureOffset("_MainTex", offset); }
}

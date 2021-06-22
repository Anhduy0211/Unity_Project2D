using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject enemy;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreatePlane());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreatePlane()
    {
        yield return new WaitForSeconds(2);

        Vector2 temp = transform.position;
        temp.y += Random.Range(-2, 0);

        Instantiate(enemy, temp, this.transform.rotation);

        StartCoroutine(CreatePlane());
    }
}

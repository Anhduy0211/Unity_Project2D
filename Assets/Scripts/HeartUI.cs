using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoBehaviour
{
    public Sprite[] HeartSpirte;// Kiểm soát máu
    public Knight knight;// Thay đổi UI theo máu Knight
    public Image Heart;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        Heart.sprite = HeartSpirte[knight.OurHeart];
    }
}

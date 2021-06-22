using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firespell;
    public Transform firepoint;

    public KnightAttack knight;

    public float manaSpell=25f;
    public ManaUI manaUi;
    public SoundManager sm;
    // Update is called once per frame
    public void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<KnightAttack>();
        manaUi = GameObject.Find("ManaUI").GetComponent<ManaUI>();        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) &&knight.attacking==false &&manaUi.staminaUI.value>=50 )
        {
            sm.PlaySounds("mage_fireball");
            manaUi.UseStamina(20);
                StartCoroutine(Shoot());              
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject fp= Instantiate(firespell, firepoint.position, firepoint.rotation);
        Destroy(fp, 1.5f);
    }
}

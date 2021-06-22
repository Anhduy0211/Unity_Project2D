using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, attack, destroyTurret, fireSpell, mage_fireball, sword_attack, hurt, shoot_tower,jumping;
    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Coins");//Resources là tên Folder trong unity chứa các file âm thanh do Unity hỗ trợ làm sound effect cho các project vừa or nhỏ
        attack = Resources.Load<AudioClip>("Attack");
        destroyTurret = Resources.Load<AudioClip>("TurretDestroy");
        fireSpell = Resources.Load<AudioClip>("FireSpell");
        mage_fireball = Resources.Load<AudioClip>("mage_fireball");
        sword_attack = Resources.Load<AudioClip>("sword_attack");
       hurt = Resources.Load<AudioClip>("hurt");
        shoot_tower = Resources.Load<AudioClip>("shoot_tower");
        jumping = Resources.Load<AudioClip>("jumping");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   public void PlaySounds(string clip)
    {
        switch (clip)
        {
            case "coins":
                audiosrc.clip = coins;
                audiosrc.PlayOneShot(coins, 0.6f);
                break;
            case "attack":
                audiosrc.clip = attack;
                audiosrc.PlayOneShot(attack, 0.7f);
                break;
            case "destroy":
                audiosrc.clip = destroyTurret;
                audiosrc.PlayOneShot(destroyTurret, 1f);
                break;
            case "firespell":
                audiosrc.clip = fireSpell;
                audiosrc.PlayOneShot(fireSpell, 0.5f);
                break;
            case "mage_fireball":
                audiosrc.clip = mage_fireball;
                audiosrc.PlayOneShot(mage_fireball, 0.5f);
                break;
            case "sword_attack":
                audiosrc.clip = sword_attack;
                audiosrc.PlayOneShot(sword_attack, 0.5f);
                break;
            case "hurt":
                audiosrc.clip = hurt;
                audiosrc.PlayOneShot(hurt, 0.5f);
                break;
            case "shoot_tower":
                audiosrc.clip = shoot_tower;
                audiosrc.PlayOneShot(shoot_tower, 0.3f);
                break;
            case "jumping":
                audiosrc.clip = jumping;
                audiosrc.PlayOneShot(jumping, 1f);
                break;
        }
    }
}

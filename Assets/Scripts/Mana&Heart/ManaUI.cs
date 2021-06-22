using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaUI : MonoBehaviour
{
    public Slider staminaUI;
    public int Stamina_Max = 100;
    public int currentStamina;
    public float manaAmount;
    public float ManaRegenAmount=20f;

    private WaitForSeconds regenTime = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static ManaUI instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = Stamina_Max;
        staminaUI.maxValue = Stamina_Max;
        staminaUI.value = Stamina_Max;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void UseStamina(int amount)
    {
        if (currentStamina - amount > 0)
        {        
            currentStamina -= amount;
            staminaUI.value = currentStamina;
            
            if (regen != null)
            {
                StopCoroutine(regen);  
            }
            regen = StartCoroutine(RegenStamina());

        }
        else
        {
            Debug.Log(currentStamina);
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2f);
        while (currentStamina < Stamina_Max)
        {
            currentStamina += Stamina_Max / 100;
            staminaUI.value = currentStamina;
            yield return regenTime; // Tạo biến regenTime cố định để thời gian regen k bị cộng dồn
        }
        regen = null;
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    public Slider HealthBar;
    public Slider EnergyBar;
    public float Health = 100;
    public float Energy = 50;

    private float currentHealth;
    private float currentEnergy;

    public StatusManager status;
    private void Start()
    {

        currentHealth = Health;
        currentEnergy = Energy;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;
    }

    public void SkillUsed(float Cost)
    {
        currentEnergy -= Cost;
        EnergyBar.value = currentEnergy;
    }

    public void NoEnergy()
    {
        status.StartCoroutine(RefillEnergy());
    }

    public IEnumerator RefillEnergy() {

        yield return new WaitForSeconds(15);
        if(EnergyBar.value < Energy)
        {
            currentEnergy += 5;
            EnergyBar.value = currentEnergy;
        }

    }

}

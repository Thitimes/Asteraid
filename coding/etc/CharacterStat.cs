using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public Transform HealthBar;
    public float maxHealth;
    public float currentHealth;
    string StrDamage;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
     
        
        Debug.Log("damage Taken");
        
        if (FloatingTextPrefab && currentHealth > 0)
        {
            ShowFloatingText(damage);
        }
    }

    public float CurrentHealthNormalized()
    {
        return currentHealth / maxHealth;
    }
    void ShowFloatingText(int damage)
    {
        var go = Instantiate(FloatingTextPrefab,HealthBar.position, Quaternion.identity, HealthBar);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }
}

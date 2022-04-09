using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offSet;
    public Transform bar;
    public CharacterStat characterStat;
    
    [SerializeField] private float sizeNormalized;
    void Start()
    {
        
        
    }
    void Update()
    {
        transform.position = targetTransform.position + offSet;
        sizeNormalized = characterStat.CurrentHealthNormalized();
        SetSize();
    }

    public void SetSize()
    {
        bar.localScale = new Vector3(Mathf.Abs(sizeNormalized), 1f,1f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(SpriteRenderer))]
public class OrbComponent : MonoBehaviour
{
    SpriteRenderer _renderer;

    [SerializeField] OrbData _orbData;
    
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateOrb();
    }

    public OrbData SwapOrbs(OrbData orbSent)
    {
        OrbData orbReturned = _orbData;
        _orbData = orbSent;
        UpdateOrb();
        return orbReturned;
    }

    void UpdateOrb()
    {
        _renderer.color = _orbData.color;
    }


}

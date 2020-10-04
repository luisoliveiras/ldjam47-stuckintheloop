using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] List<TriggerComponent> _orbHolders;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var orbHolder in _orbHolders)
        {
            if (orbHolder.ContainOrb(_playerData.currentOrb))
            {
                orbHolder.SwapOrbs(_playerData.noOrb);
            }
        }
    }
}

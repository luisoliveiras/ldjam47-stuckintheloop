using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerData", fileName = "new PlayerData")]
public class PlayerData : ScriptableObject 
{
    public OrbData currentOrb;
    public OrbData noOrb;

    public void ResetOrbs()
    {
        currentOrb = noOrb;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable Objects/SceneChanger", fileName = "new SceneChanger")]
public class SceneChanger : ScriptableObject 
{
    [SerializeField] string _home;
    [SerializeField] string _game;
    [SerializeField] string _endgame;

    public void MoveToHome()
    {
        SceneManager.LoadScene(_home);
    }

    public void MoveToGame()
    {
        SceneManager.LoadScene(_game);
    }

    public void MoveToEndGame()
    {
        SceneManager.LoadScene(_endgame);
    }
}
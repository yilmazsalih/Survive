using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public Fire fire;
    public EnemyController enemyController;
    public void OnStart()
    {
        playerController.canMove = true;
        fire.canAttack = true;
        enemyController.canSpawn = true;
        //karakter ate� etmeye ba�layacak
        //d��manlar gelma�a ba�layacak
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

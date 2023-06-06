using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public PlayerController playerController;
    public Fire fire;
    public EnemyController enemyController;
    public TMP_Text levelText;
    private void Awake()
    {
        level= PlayerPrefs.GetInt("level",1);
        levelText.text = "Level: " + level;
    }
    public void OnStart()
    {
        playerController.canMove = true;
        fire.canAttack = true;
        enemyController.canSpawn = true;
        //karakter ateþ etmeye baþlayacak
        //düþmanlar gelmaða baþlayacak
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void OnClickNextLevelButton()
    {
        level++;
        PlayerPrefs.SetInt("level",level);
        RestartLevel();
    }
}

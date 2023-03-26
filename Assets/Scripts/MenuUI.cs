using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI NameText;
    private int highScore;

    void Start(){
        BestScore();
    }

    public void NameEntered(string name){
        ManagerWorks.Instance.CurrentPlayer = name;
    }

    void BestScore()
    {
        name = ManagerWorks.Instance.Name;
        highScore = ManagerWorks.Instance.highScore;
        NameText.text = name;
        BestScoreText.text = $"Best Score : {name} : {highScore}";
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}

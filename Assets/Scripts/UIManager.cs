using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text endGame;

    private int _score;
    // [SerializeField] EventSystemCustom eventSystemCustom;
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        CustomEventSystem.current.onEndGame.AddListener(UpdateEndGame);
        CustomEventSystem.current.onScoreChange.AddListener(UpdateScore);
        UpdateScore(0);

    }
    private void UpdateScore(int addedScore)
    {
        _score += addedScore;
        score.text = "Score : " + _score;
    }
    private void UpdateEndGame()
    {
        endGame.text = "You lose!\nYour Score is "+_score;
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer(){
        //when we click on the button to check if it is the right answer
        if(isCorrect){
            Debug.Log("correct!");
            quizManager.correct();
        }
        else{
            Debug.Log("Wrong!");
            quizManager.wrong();

        }
    }
}

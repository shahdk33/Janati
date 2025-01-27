using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<Questions> QnA; 
    public GameObject [] options;
    public int currentQuestionIndex;

    public TextMeshProUGUI QuestionText;

    public GameObject QuizPanel;
    public GameObject PointsPanel;

    public TextMeshProUGUI ScoreText;
    public int TotalQuestions = 0;
    public int score;


    public void Start(){
        TotalQuestions= QnA.Count;
        PointsPanel.SetActive(false);
        generateQuestion();
    }

    public void GameOver(){

        int coins = score * 100;
        GameDataManager.Gold += coins;

        //show points
        PointsPanel.SetActive(true);
        QuizPanel.SetActive(false);

        //Score to coins ammount
        ScoreText.text = score + "/" + TotalQuestions + " that's " + coins + " coins!";
        //TODO: need to send the coins to gold variable in Gold.cs

    }

    //garden button
    public void goToGarden(){
        SceneManager.LoadSceneAsync(1);
    }

    public void correct(){
        score +=1;
        QnA.RemoveAt(currentQuestionIndex);
        generateQuestion();
    }

    public void wrong(){
        QnA.RemoveAt(currentQuestionIndex);
        generateQuestion();

    }
    

    public void setAnswers(){
        //each button has a text child element
        for (int i=0; i< options.Length; i++){

            //make all answers false initially
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            
            //get the child which is the text of the button, so we get each answer option
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestionIndex].Answers[i];

            //only the right index option will have true boolean
            if (QnA[currentQuestionIndex].CorrectAnswer == i){
                options[i].GetComponent<AnswerScript>().isCorrect = true;

            }
        } 
    }

    public void generateQuestion(){

//if there are more questions left
        if(QnA.Count > 0){
        //get random Q from list - random index FROM 0 until end of list 
        currentQuestionIndex = Random.Range(0, QnA.Count);

        //text = the question object in the QnA list 
        QuestionText.text = QnA[currentQuestionIndex].Question;

        setAnswers();
        }
        else{
            //done questions
            Debug.Log("Done questions!");

            //show points panel and dont show the quiz panel        
            GameOver();
        }
    }
}

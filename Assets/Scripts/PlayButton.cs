using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayQuiz(){
        SceneManager.LoadSceneAsync(2);
    }


}

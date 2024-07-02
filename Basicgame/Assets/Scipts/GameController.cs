using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public AudioSource src;
  public AudioClip button;
  public void PlayGame(){
    src.clip = button;
    src.Play();
   SceneManager.LoadScene("Gameplay");
  }

  public void Menu(){

    SceneManager.LoadScene("MainMenu");
  }

  public void Rebutton(){


    SceneManager.LoadScene("Gameplay");
  }
  public void Quit(){
    src.clip = button;
    src.Play();
    Application.Quit();
  }

}

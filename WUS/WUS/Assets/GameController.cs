using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject option;
    public GameObject Sceneobject;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    void Quit()
    {
      option.gameObject.SetActive(true);
      Sceneobject.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();
        {
            //UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GameFinish()
    {

        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        		Application.OpenURL("http://www.yahoo.co.jp/");
        #else
        		Application.Quit();
        #endif
        
    }
    public void Cancel()
    {
        option.gameObject.SetActive(false);
        Sceneobject.gameObject.SetActive(true);
    }
    public void tutorial()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

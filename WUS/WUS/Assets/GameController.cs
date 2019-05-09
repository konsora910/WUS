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
#if UNITY_EDITOR


#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();


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
        UnityEditor.EditorApplication.isPlaying = false;
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
    public void stage1()
    {

    }
    public void stage2()
    {

    }
    public void stage3()
    {

    }
    public void stage4()
    {

    }
    public void stage5()
    {

    }
}

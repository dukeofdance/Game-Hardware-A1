using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Begin()
    {
        SceneManager.LoadScene("intro");
    }
    public void Replay()
    {
        SceneManager.LoadScene("Tire");
    }
}

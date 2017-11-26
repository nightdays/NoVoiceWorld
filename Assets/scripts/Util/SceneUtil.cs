using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public class SceneUtil : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string sceneName = "";

    public int sceneId = 0;

    public void GoToScene()
    {
        ScreenUI screenUI = Game.ScreenUI(); 
        if("".Equals(sceneName)){
            screenUI.FadeAndGo(sceneId);
        }else{
            screenUI.FadeAndGo(sceneName);
        }
    }

}

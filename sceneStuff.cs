using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneStuff : MonoBehaviour
{
   
    public void moveToScene(int indexOfScene)
    {
        SceneManager.LoadSceneAsync(indexOfScene);
    }

}

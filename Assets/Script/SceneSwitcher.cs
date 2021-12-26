using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination;

    public void OnPointerClick(PointerEventData e)//IPointerClickHandler裡要實作！
    {
        //get current scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current scene name = " + scene.name + " and scene index = " + scene.buildIndex);


        //
        SceneManager.LoadScene(SceneIndexDestination);

    }
}

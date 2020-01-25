using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARCanvas : MonoBehaviour
{
    public GameObject panel;
    public GameObject information;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPanel()
    {
        if(panel != null)
        {
            panel.SetActive(true);
            information.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        information.SetActive(true);
    }

   public void Pushed()
   {
        SceneManager.LoadScene("MainScenePostAr");
   }

}

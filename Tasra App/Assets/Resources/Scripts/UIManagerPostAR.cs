using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManagerPostAR : MonoBehaviour
{
    public RectTransform languageMenu, menuPrincipal, mainMenu,
            instruccionesMenu, instructionsMenu, obrasMenu, artworksMenu, curatorialEsp, curatorialEng;

    public static UIManagerPostAR instance;

    // Start is called before the first frame update
    void Start()
    {
        if (UIManager.instance.isEnglish)
        {
            artworksMenu.DOAnchorPos(Vector2.zero, 0.5f);
        }
        else
        {
            obrasMenu.DOAnchorPos(Vector2.zero, 0.5f);
        }
        BackgroundFX.instance.Unpause();
    }

    public void LanguageButtonEspanol()
    {
        languageMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        menuPrincipal.DOAnchorPos(new Vector2(0, 0), 0.25f);
        UIManager.instance.isEnglish = false;
    }

    public void LanguageButtonEnglish()
    {
        languageMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        UIManager.instance.isEnglish = true;
    }

    public void StartItem()
    {
        curatorialEng.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        artworksMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void Quit()
    {
        mainMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        languageMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        //Application.Quit(); not being used at the moment
    }

    public void Instructions()
    {
        mainMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        instructionsMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void Empezar()
    {
        curatorialEsp.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        obrasMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void Salir()
    {
        menuPrincipal.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        languageMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        //Application.Quit(); not being used at the moment
    }

    public void Instrucciones()
    {
        menuPrincipal.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        instruccionesMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void BackInstructions()
    {
        instructionsMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void VolverInstrucciones()
    {
        instruccionesMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        menuPrincipal.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void BackToMain()
    {
        curatorialEng.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void VolverPrincipal()
    {
        curatorialEsp.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        menuPrincipal.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void showCuratorialEsp()
    {
        menuPrincipal.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        curatorialEsp.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void showCuratorialEng()
    {
        mainMenu.DOAnchorPos(new Vector2(-3100, 0), 0.25f);
        curatorialEng.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void backToCuratorial()
    {
        artworksMenu.DOAnchorPos(new Vector2(3100, 0), 0.25f);
        curatorialEng.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void volverACuratorial()
    {
        obrasMenu.DOAnchorPos(new Vector2(3100, 0), 0.25f);
        curatorialEsp.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void AR()
    {
        //cambiar a ARScene
        BackgroundFX.instance.Pause();
        SceneManager.LoadScene("ARScene");
    }
}

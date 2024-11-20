using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPopUps : MonoBehaviour
{
    [SerializeField]
    GameObject PopUpTienda;
    [SerializeField]
    GameObject PopUpMenu;
    [SerializeField]
    GameObject ButtonAparecerMenu;
    [SerializeField]
    GameObject ButtonAparecerTienda;
    [SerializeField]
    GameObject camara;
    [SerializeField]
    float durationAnimation;
    [SerializeField]
    float positionYAnimation;
    [SerializeField]
    float positionXAnimation;

    Vector3 posicionCerca = new Vector3(-2.96f, 1.19f, 0.05f);
    Vector3 posicionLejos = new Vector3(-3.6f, 1.47f, -1.09f);

    // Start is called before the first frame update
    void Start()
    {
        PopUpTienda.SetActive(false);
        PopUpMenu.SetActive(false);
        LeanTween.move(camara, posicionCerca, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AparecerMenu()
        {
        ButtonAparecerMenu.SetActive(false);
        LeanTween.moveLocalY(PopUpMenu, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
        PopUpMenu.SetActive(true);
        LeanTween.move(camara, posicionLejos, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);



    }
    public void AparecerTienda()
        {
        ButtonAparecerTienda.SetActive(false);
        LeanTween.moveLocalX(PopUpTienda, positionXAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
        PopUpTienda.SetActive(true);
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotar : MonoBehaviour
{
    [SerializeField]
    GameObject PopUpMenu;
    [SerializeField]
    GameObject PopUpTienda;
    [SerializeField]
    GameObject PopUpRotar;
    [SerializeField]
    GameObject objetoSeleccionado;
    [SerializeField]
    GameObject objetoGolpeado;
    [SerializeField]
    GameObject camara;

    [SerializeField]
    float durationAnimation;
    [SerializeField]
    float positionYAnimation;
    [SerializeField]
    float position2YAnimation;
    [SerializeField]
    float positionXAnimation;
    [SerializeField]
    float position2XAnimation;
    [SerializeField]
    float desplazamientoRueda;
    [SerializeField]
    float velocidadRotacion;

    Vector3 posicionCerca = new Vector3(-2.96f, 1.19f, 0.05f);
    Vector3 posicionLejos = new Vector3(-3.6f, 1.47f, -1.09f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SeleccionarObjeto();
        }

        desplazamientoRueda = Input.GetAxis("Mouse ScrollWheel");

        if (desplazamientoRueda != 0 && PopUpRotar.activeSelf)
        {
            objetoSeleccionado.transform.Rotate(0f, desplazamientoRueda * velocidadRotacion, 0f);
        }



        if (Input.GetMouseButtonUp(1) & PopUpRotar.activeSelf)
        {
            //PopUpMenu.SetActive(true);
            LeanTween.moveLocalY(PopUpMenu, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

            LeanTween.moveLocalY(PopUpRotar, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            PopUpRotar.SetActive(false);

            LeanTween.move(camara, posicionLejos, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        }
    }

    public void SeleccionarObjeto()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objetoGolpeado = hit.collider.gameObject;

            if (objetoSeleccionado == objetoGolpeado)
            {
                DeseleccionarObjeto();
            }

            if (objetoSeleccionado != null)
            {
                DeseleccionarObjeto();
            }

            objetoSeleccionado = objetoGolpeado;
        }
    }

    public void DeseleccionarObjeto()
    {
        objetoSeleccionado = null;
    }

    public void RotarObjeto()
    {
        //PopUpMenu.SetActive(false);
        LeanTween.moveLocalY(PopUpMenu, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        //PopUpTienda.SetActive(false);
        LeanTween.moveLocalX(PopUpTienda, position2XAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        PopUpRotar.SetActive(true);
        LeanTween.moveLocalY(PopUpRotar, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);


        LeanTween.move(camara, posicionCerca, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

    }
}

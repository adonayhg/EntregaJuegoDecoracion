using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    GameObject PopUpMenu;
    [SerializeField]
    GameObject PopUpTienda;
    [SerializeField]
    GameObject PopUpMover;
    [SerializeField]
    GameObject objetoSeleccionado;
    [SerializeField]
    GameObject objetoGolpeado;
    [SerializeField]
    GameObject camara;
    [SerializeField]
    GameObject circulo;

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

    Vector3 posicionCerca = new Vector3(-2.96f, 1.19f, 0.05f);
    Vector3 posicionLejos = new Vector3(-3.6f, 1.47f, -1.09f);
    Vector3 escaladoCirculo = new Vector3(0.5f, 0.003f, 0.5f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SeleccionarObjeto();
        }

        if (Input.GetMouseButtonUp(1) & PopUpMover.activeSelf)
        {
            //PopUpMenu.SetActive(true);
            LeanTween.moveLocalY(PopUpMenu, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            
            LeanTween.moveLocalY(PopUpMover, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            PopUpMover.SetActive(false);

            LeanTween.move(camara, posicionLejos, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            circulo.SetActive(false);
            objetoSeleccionado = null;
        }

        if (PopUpMover.activeSelf)
        {
            objetoSeleccionado.SetActive(false);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                objetoSeleccionado.transform.position = hit.point;
                circulo.transform.position = hit.point;
                circulo.transform.parent = objetoSeleccionado.transform;
            }
            objetoSeleccionado.SetActive(true);
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
        circulo.SetActive(true);

    }

    public void DeseleccionarObjeto()
    {
        objetoSeleccionado = null; //null hace referencia a que no hay ningun valor asignado
    }

    public void MoverObjeto()
    {
        //PopUpMenu.SetActive(false);
        LeanTween.moveLocalY(PopUpMenu, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
        //PopUpTienda.SetActive(false);
        LeanTween.moveLocalX(PopUpTienda, position2XAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        DeseleccionarObjeto();
        PopUpMover.SetActive(true);
        LeanTween.moveLocalY(PopUpMover, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        LeanTween.move(camara, posicionCerca, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        circulo.transform.localScale = new Vector3(1.9f, 0.003f, 1.9f);

        if (circulo.transform.localScale == new Vector3(1.9f, 0.003f, 1.9f))
        {
            LeanTween.scale(circulo, escaladoCirculo, 35 * Time.deltaTime).setLoopPingPong().setEase(LeanTweenType.easeInSine);
        }


    }
}

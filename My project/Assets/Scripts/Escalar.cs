using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalar : MonoBehaviour
{
    [SerializeField]
    GameObject PopUpMenu;
    [SerializeField]
    GameObject PopUpTienda;
    [SerializeField]
    GameObject PopUpEscalar;
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
    Vector3 escalado = new Vector3(0.01f, 0.01f, 0.01f);
    Vector3 maxEscala = new Vector3(1.2f, 1.2f, 1.2f);
    Vector3 minEscala = new Vector3(0.8f, 0.8f, 0.8f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SeleccionarObjeto();
        }

        desplazamientoRueda = Input.GetAxis("Mouse ScrollWheel");

        if (desplazamientoRueda >= 0 && PopUpEscalar.activeSelf)
        {
            objetoSeleccionado.transform.localScale += escalado;

            if(objetoSeleccionado.transform.localScale == maxEscala)
            {
                desplazamientoRueda = 0;
            }
        }

       if (desplazamientoRueda <=0 && PopUpEscalar.activeSelf)
        {
            objetoSeleccionado.transform.localScale -= escalado;

            if (objetoSeleccionado.transform.localScale == minEscala)
            {
                desplazamientoRueda = 0;
            }
        }

        if (objetoSeleccionado.transform.localScale.y < 0.8f)
        {
            objetoSeleccionado.transform.localScale = minEscala;
        }


        if (Input.GetMouseButtonUp(1) & PopUpEscalar.activeSelf)
        {
            //PopUpMenu.SetActive(true);
            LeanTween.moveLocalY(PopUpMenu, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

            LeanTween.moveLocalY(PopUpEscalar, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            PopUpEscalar.SetActive(false);

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


    public void EscalarObjeto()
    {
        //PopUpMenu.SetActive(false);
        LeanTween.moveLocalY(PopUpMenu, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        //PopUpTienda.SetActive(false);
        LeanTween.moveLocalX(PopUpTienda, position2XAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

        PopUpEscalar.SetActive(true);
        LeanTween.moveLocalY(PopUpEscalar, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);


        LeanTween.move(camara, posicionCerca, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
    }
}

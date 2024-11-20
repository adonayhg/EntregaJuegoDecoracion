using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField]
    GameObject preFab;
    [SerializeField]
    GameObject objetoCreado;
    [SerializeField]
    GameObject PopUpMenu;
    [SerializeField]
    GameObject PopUpTienda;
    [SerializeField]
    GameObject PopUpCrear;
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


    bool objetoMovimiento = false;

    Vector3 posicionCerca = new Vector3(-2.96f, 1.19f, 0.05f);
    Vector3 posicionLejos = new Vector3(-3.6f, 1.47f, -1.09f);

    // Start is called before the first frame update
    void Start()
    {
        preFab.SetActive(false);
        PopUpCrear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
            if (objetoMovimiento)
            {
                objetoCreado.SetActive(false);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    objetoCreado.transform.position = hit.point;
                }
                objetoCreado.SetActive(true);


                if (Input.GetMouseButtonUp(1))
                {
                    objetoMovimiento = false;
                    //PopUpMenu.SetActive(true);
                    LeanTween.moveLocalY(PopUpMenu, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

                    //PopUpTienda.SetActive(true);
                    LeanTween.moveLocalX(PopUpTienda, positionXAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

                    LeanTween.moveLocalY(PopUpCrear, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
                    PopUpCrear.SetActive(false);

                    //Camera.main.transform.position = posicionLejos;
                    LeanTween.move(camara , posicionLejos, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);
            }
            }
    }
    public void CrearObjeto() 
    {
            objetoCreado = Instantiate(preFab, Vector3.zero, Quaternion.identity);
            objetoCreado.SetActive(true);
            objetoMovimiento= true;
            //PopUpMenu.SetActive(false);
            LeanTween.moveLocalY(PopUpMenu, position2YAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

            //PopUpTienda.SetActive(false);
            LeanTween.moveLocalX(PopUpTienda, position2XAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);


            PopUpCrear.SetActive(true);
            LeanTween.moveLocalY(PopUpCrear, positionYAnimation, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);


            //Camera.main.transform.position = posicionCerca;
            LeanTween.move(camara, posicionCerca, durationAnimation * Time.deltaTime).setEase(LeanTweenType.easeInSine);

    }
}

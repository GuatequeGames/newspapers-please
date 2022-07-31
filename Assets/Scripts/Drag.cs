using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{
    public string verb;

    Vector3 offset;
    public Vector3 verbTransform;
    public bool isTrigger;
    public bool isVerbTrigger;
    public bool isNewspaperTrigger;
    public bool isStamp;
    public bool isInkTrigger;
    public bool isSceneTrigger;
    public bool isAssetTrigger;
    public bool isInkExit;
    public bool canExitStamp;
    public bool canStamp;
    public bool canRestartStamp;
    public bool isEndExitTrigger;
    public bool isEndRestartTrigger;
    public GameObject stamp;
    public Animator anim;

    AudioSource audioSource;
    public AudioClip audioInk;
    public AudioClip audioWood;
    public bool maderasound;

    public float speedRotation;
    float timerRotation;

    public GameObject photoBuena;
    public GameObject[] photosMalas;
    public GameObject photoNeutral;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isSceneTrigger = true;
    }
    private void Update()
    {
        if (isStamp)
        {
            if (GameManager.instance.resetMatasellos)
            {
                
                anim.SetBool("up", false);
                anim.SetBool("putStamp", false);
                anim.SetTrigger("reset");
                isStamp = false;
                isNewspaperTrigger = false;
                GameManager.instance.resetMatasellos = false;
            }
        }
    }

    //ESTO SE EJECUTA UN SOLO FRAME CUANDO PULSAMOS
    private void OnMouseDown()//Cuando hago click con el boton izquierdo del raton
    {
        if (gameObject.tag == "Stamp")
        {
            isStamp = true;
            anim.SetBool("up", true);
            if (isInkTrigger)
            {
                canStamp = true;
            }
            if (isInkExit || isEndExitTrigger)
            {
                canExitStamp = true;
            }
            verbTransform = this.transform.position;
            
        }
        else isStamp = false;
        if (!isVerbTrigger)
        {
            verbTransform = this.transform.position;
        }
        Vector2 mousePos = Input.mousePosition; //Coordenadas de pantalla
        //Estoy cogiendo la distancia que hay desde el gameObject a la c�mara
        float distance = Camera.main.WorldToScreenPoint(transform.position).z; //WorldToScreenPoint devuelve (cordenada pantalla, cordenada pantalla, distancia de pantalla) ejemplo en el extremo de la pantalla (1920,1080,23pixeles)
        //Calculo en coordenadas de mundo dejuego (Dela escena de Unity) la posicion del rat�n
        //TENIENDO EN CUENTA LA DESITANCIA Q LA QUE ESTA EL GAMEOBJECT
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
        //el oofset lo calculo para que a la hora de pinchar sobre el bojeto, el sguimiento del objeto al cursor del raton
        //se haga precisamente sobre el punto sobre el que hemos pinchado
        offset = transform.position - worldPos;
    }
    //eSTO SE EJECUTA SIEMPRE QUE ESTEMOS ARRASTRANDO EL RATON CON EL BOTON PULSADO
    private void OnMouseDrag()//Cuando arrastro el raton
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        //EN ESTA LINEA LE DIGO AL OBJETO QUE SE MUEVA.
        //El offset hace que se mueva desde el punto donde he hecho click y no sobre el centro del objeto
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance)) + offset;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, speedRotation*timerRotation );
        timerRotation += Time.deltaTime;
        if (!isStamp)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }

    }
    private void OnMouseUp()
    {
        if (!isStamp)
        {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        timerRotation = 0;
        
            if (!isTrigger && !isVerbTrigger)
            {
                transform.position = verbTransform;
                if (GameManager.instance.verbList.Count == 1)
                {
                    if (GameManager.instance.verbList[0] == verb)
                    {
                        GameManager.instance.verbList.RemoveAt(0);
                        this.GetComponent<Rigidbody2D>().isKinematic = false;
                        StopAllCoroutines();

                        StartCoroutine(fadeToNeutral());

                    }
                }
            }
            else if (isVerbTrigger)
            {
                if (GameManager.instance.verbList.Count == 0)
                {
                    GameManager.instance.EditNewsPaper(verb, this.gameObject);
                    GameManager.instance.verbList.Add(verb);

                    this.GetComponent<Rigidbody2D>().isKinematic = true;
                    StopAllCoroutines();

                    StartCoroutine(fadeToNotice());
                }
                else if (GameManager.instance.verbList.Count == 1)
                {
                    if (GameManager.instance.verbList[0] == verb)
                    {
                        GameManager.instance.EditNewsPaper(verb, this.gameObject);
                    }
                    else
                    {
                        GameManager.instance.verbObject.transform.position = GameManager.instance.verbObject.GetComponent<Drag>().verbTransform;
                        GameManager.instance.verbObject.GetComponent<Rigidbody2D>().isKinematic = false;
                        GameManager.instance.verbList.RemoveAt(0);
                        GameManager.instance.verbList.Add(verb);
                        GameManager.instance.EditNewsPaper(verb, this.gameObject);
                        this.GetComponent<Rigidbody2D>().isKinematic = true;
                        StopAllCoroutines();

                        StartCoroutine(fadeToNotice());


                    }
                }
                if (!isVerbTrigger)
                {
                    if (GameManager.instance.verbList.Count == 1)
                    {
                        if (GameManager.instance.verbList[0] == verb)
                        {
                            GameManager.instance.verbList.RemoveAt(0);
                            isTrigger = true;
                            this.GetComponent<Rigidbody2D>().isKinematic = false;
                            StopAllCoroutines();

                            StartCoroutine(fadeToNeutral());


                        }
                    }
                }
            }
            else
            {
                if (GameManager.instance.verbList.Count == 1)
                {
                    if (GameManager.instance.verbList[0] == verb)
                    {
                        GameManager.instance.verbList.RemoveAt(0);
                        this.GetComponent<Rigidbody2D>().isKinematic = false;
                        StopAllCoroutines();
                        StartCoroutine(fadeToNeutral());

                    }
                }
            }
        }
        if (gameObject.tag == "Stamp")
        {
            if (isNewspaperTrigger && GameManager.instance.newspaperTrigger && canStamp)
            {
                anim.SetBool("putStamp", true); 
            }
            else if (isNewspaperTrigger && GameManager.instance.newspaperTrigger && canExitStamp)
            {
                Debug.Log("fin");
                Application.Quit();
            }
            else if (isNewspaperTrigger && GameManager.instance.newspaperTrigger && canRestartStamp)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                isStamp = false;
                anim.SetBool("up", false);
                canStamp = false;
                if(!isSceneTrigger || isAssetTrigger)
                {
                    isSceneTrigger = true;
                    isAssetTrigger = false;
                    transform.position = verbTransform;
                }
                if (isInkTrigger)
                {
                    maderasound = false;
                }
                else
                {
                    maderasound = true;
                }
            }
        }

    }
    public void MatasellosVolumenControl()
    {
        if (maderasound)
        {
            audioSource.PlayOneShot(audioWood, 0.7f);
        }
        else
        {
            audioSource.PlayOneShot(audioInk, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isStamp)
        {
            //isTrigger = true;
            if (collision.gameObject.tag == "Verb")
            {
                isVerbTrigger = true;
            }
            if (collision.gameObject.tag == "Answer")
            {
                isTrigger = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Newspaper")
            {
                isNewspaperTrigger = true;
            }
            if (collision.gameObject.tag == "Ink")
            {
                isInkTrigger = true;
            }
            if (collision.gameObject.tag == "ExitInk")
            {
                isInkExit = true;
            }
            if (collision.gameObject.tag == "Scene")
            {
                isSceneTrigger = true;
            }
            if (collision.gameObject.tag == "Asset")
            {
                isAssetTrigger = true;
            }
            if (collision.gameObject.tag == "EndExitInk")
            {
                isEndExitTrigger = true;
            }
            if (collision.gameObject.tag == "EndRestartInk")
            {
                isEndRestartTrigger = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isStamp)
        {
            //isTrigger = false;
            if (collision.gameObject.tag == "Verb")
            {
                isVerbTrigger = false;
            }
            if (collision.gameObject.tag == "Answer")
            {
                isTrigger = false;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Newspaper")
            {
                isNewspaperTrigger = false;
            }
            if (collision.gameObject.tag == "Ink")
            {
                isInkTrigger = false;
            }
            if (collision.gameObject.tag == "ExitInk")
            {
                isInkExit = false;
            }
            if (collision.gameObject.tag == "Scene")
            {
                isSceneTrigger = false;
            }
            if (collision.gameObject.tag == "Asset")
            {
                isAssetTrigger = false;
            }
            if (collision.gameObject.tag == "EndExitInk")
            {
                isEndExitTrigger = false;
            }
            if (collision.gameObject.tag == "EndRestartInk")
            {
                isEndRestartTrigger = false;
            }
        }
    }
    public void putStamp()
    {
        stamp.SetActive(true);
        stamp.transform.SetParent(null);

        if (GameManager.instance.verbList.Count > 0)
        {
            GameManager.instance.options[GameManager.instance.actualDay] = GameManager.instance.verbList[0];
        } else
        {
            GameManager.instance.options[GameManager.instance.actualDay] = null;
        }
        
        GameManager.instance.goToNextDay();
    }


    IEnumerator fadeToNotice()
    {
        yield return new WaitForSeconds(0.3f);
        for(int i = 0; i<photosMalas.Length; i++)
        {
            while (photosMalas[i].GetComponent<SpriteRenderer>().color.a > 0)
            {
                Color tmp = photosMalas[i].GetComponent<SpriteRenderer>().color;
                tmp.a -= 0.006f;
                photosMalas[i].GetComponent<SpriteRenderer>().color = tmp;
                yield return null;
            }
        }
        

        while (photoBuena.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color tmp = photoBuena.GetComponent<SpriteRenderer>().color;
            tmp.a += 0.006f;
            photoBuena.GetComponent<SpriteRenderer>().color = tmp;
            yield return null;
        }
    }

    IEnumerator fadeToNeutral()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < photosMalas.Length; i++)
        {
            while (photoBuena.GetComponent<SpriteRenderer>().color.a >0)
            {
                Color tmp = photoBuena.GetComponent<SpriteRenderer>().color;
                tmp.a -= 0.006f;
                photoBuena.GetComponent<SpriteRenderer>().color = tmp;
                yield return null;
            }

        }


        while (photoNeutral.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color tmp = photoNeutral.GetComponent<SpriteRenderer>().color;
            tmp.a += 0.006f;
            photoNeutral.GetComponent<SpriteRenderer>().color = tmp;
            yield return null;
        }
    }
}

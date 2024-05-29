using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    public float güç = 10f;
    public float xfor, yfor;
    public Rigidbody2D rb;
    public TrajectoryLine tl;
    public GameManager gameManager;
    public AudioSource aso;

    public Vector2 minPower,
                   maxPower;

    Camera cam;

    Vector2 force;
    Vector3 startP,
            endP;

    public AudioClip[] clips;

    public bool öldü , durdu = false;

    public void Start()
    {
        cam = Camera.main;

        if (gameManager == null)
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        aso = GetComponent<AudioSource>();

        tl = GetComponent<TrajectoryLine>();
        öldü = false;

        if (PlayerPrefs.GetInt("Can") <= 0)
            durdu = true;
        else
            durdu = false;
    }

    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            startP = cam.ScreenToWorldPoint(Input.mousePosition);
            startP.z = 15;

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currP = cam.ScreenToWorldPoint(Input.mousePosition);
            currP.z = 15;

            Vector3 chunk = new Vector3(Mathf.Clamp(currP.x - startP.x, minPower.x, maxPower.x),
                                        Mathf.Clamp(currP.y - startP.y, minPower.y, maxPower.y), 0);
            if(!öldü && !durdu)
            {
                if(gameManager.kalanDHakkı > gameManager.hareketSay)
                    tl.RenderLine(transform.position, transform.position - chunk);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endP = cam.ScreenToWorldPoint(Input.mousePosition);
            endP.z = 15;

            force = new Vector2(Mathf.Clamp(startP.x - endP.x, minPower.x, maxPower.x), 
                                Mathf.Clamp(startP.y - endP.y, minPower.y, maxPower.y));
            tl.EndLine();
            if (!öldü && !durdu)
            {
                if(Mathf.Abs(force.x) > xfor || Mathf.Abs(force.y) > yfor)
                {
                    if(gameManager.kalanDHakkı > gameManager.hareketSay)
                    {
                        gameManager.HareketEtti();
                        rb.AddForce(force * güç, ForceMode2D.Impulse);
                        aso.clip= clips[2];
                        aso.Play();
                    }
                    else
                    {
                        gameManager.Wasted();
                    }
                }
            }             
        }
#elif UNITY_ANDROID
        int parmakSayisi = Input.touchCount;
 
        if (Input.touchCount > 0)
        {
             Touch parmak = Input.GetTouch( 0 );
     
             if( parmak.phase == TouchPhase.Began )
             {
                startP = cam.ScreenToWorldPoint(parmak.position);
                startP.z = 15;
             }

             else if (parmak.phase == TouchPhase.Moved)
             {
                Vector3 currP = cam.ScreenToWorldPoint(parmak.position);
                currP.z = 15;

                Vector3 chunk = new Vector3(Mathf.Clamp(currP.x - startP.x, minPower.x, maxPower.x),
                                        Mathf.Clamp(currP.y - startP.y, minPower.y, maxPower.y), 0);
                if(!öldü && !durdu)
                {
                    if(gameManager.kalanDHakkı > gameManager.hareketSay)
                    tl.RenderLine(transform.position, transform.position - chunk);
                }
            }

            if (parmak.phase == TouchPhase.Ended)
            {
                endP = cam.ScreenToWorldPoint(parmak.position);
                endP.z = 15;

                force = new Vector2(Mathf.Clamp(startP.x - endP.x, minPower.x, maxPower.x), 
                                    Mathf.Clamp(startP.y - endP.y, minPower.y, maxPower.y));
                tl.EndLine();
                if (!öldü && !durdu)
                {
                    if(Mathf.Abs(force.x) > xfor || Mathf.Abs(force.y) > yfor)
                    {
                        if(gameManager.kalanDHakkı > gameManager.hareketSay)
                        {
                            gameManager.HareketEtti();
                            rb.AddForce(force * güç, ForceMode2D.Impulse);
                            aso.clip= clips[2];
                            aso.Play();
                        }
                        else
                        {
                        gameManager.Wasted();
                        }
                    }
                }             
            }
        }


        
#endif
    }
}

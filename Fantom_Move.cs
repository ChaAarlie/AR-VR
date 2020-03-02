using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantom_Move : MonoBehaviour
{
    public float speed = 1.0f;
    private GameObject joueur;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.Find("FPSController");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("marche", false);
        Debug.Log("test");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (Vector3.Distance(transform.position, joueur.transform.position) <= 4 ){
             anim.SetBool("marche", true);
             float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, joueur.transform.position, step);
         }
    }
}

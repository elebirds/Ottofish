using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject chose ;
    public GameObject sp;
    //public GameObject moveRange;
    public float speed;
    public Vector3 playerInput;
    public bool isMove;
    private Animator anim;
    public Quaternion chushi;
    public float distance;
    public Vector2 cushiPlace;
    private void Update()
    {
        distance = Vector2.Distance(cushiPlace, (Vector2)(gameObject.transform.position));
        gameObject.transform.localRotation = chushi;
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetBool("isRun", false);
        if (isMove&&playerInput!=new Vector3(0,0,0)) 
        {
            if(Vector2.Distance(cushiPlace, (playerInput * speed * Time.deltaTime) + transform.position)<4.0f)
            transform.position = (playerInput * speed * Time.deltaTime) + transform.position;
            anim.SetBool("isRun", true);
            if (playerInput==new Vector3(-1,0,0) ) 
            {
                gameObject.transform.localScale = new Vector3(3,3,1);
            }
            if (playerInput == new Vector3(1, 0, 0))
            {
                gameObject.transform.localScale = new Vector3(-3, 3, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chose.SetActive(true);
            //moveRange.SetActive(false);
            isMove = false;
            cushiPlace=gameObject.transform.position;
        }
    }
    private void Awake()
    {
        cushiPlace = gameObject.transform.position;
        anim = GetComponent<Animator>();
        chushi = gameObject.transform.localRotation;
    }
    private void Start()
    {
        isMove = true;
        sp.SetActive(true);
    }
    public void callMove() 
    {
        Invoke("nonmove", 2f);
    }
    public void nonmove() 
    {
        isMove = true;
    }
}

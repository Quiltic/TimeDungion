using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour
{
    // Start is called before the first frame update

    public event Action Click;
    public event Action Hover;
    //UnityEvent m_MyEvent;


    public string hovering = "None";
    public string selected = "None";
    public float clickPosX = 0;
    public float clickPosY = 0;
    public string State = "None";

    public int hoverLength = 180;
    public int hoverTime = 0;


    public GameObject Heart;
    public GameObject Armor;
    public GameObject MagicArmor;

    void Start() {
        
    }
    //{
    //    Debug.Log("FACK");
        //if (m_MyEvent == null)
        //    m_MyEvent = new UnityEvent();

        //m_MyEvent.AddListener(Ping);
    //}
    // Update is called once per frame
    void Update () {
        
        if (hovering != "None") {hovering = "None";}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit hit = Physics.Raycast(mousePos, (mousePos+mousePos+mousePos));
        //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        Debug.DrawRay(mousePos, hit, Color.green);

        


        if (hit.collider != null) {
            
            hovering = hit.collider.gameObject.name;

            if (hoverTime >= hoverLength) {
                //Debug.Log("FACK");
                Hover();
            } else {
                hoverTime++;
            }


            if (Input.GetMouseButtonDown(0)) {
                if (selected == "None") {selected = hovering;} else {selected = "None";}
                
                clickPosX = mousePos.x;
                clickPosY = mousePos.y;
                Click();
                //gameObject.SendMessage(, 5.0);
            }

            //Debug.Log(lastClicked);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            
        } else { hoverTime = 0; } //if (hoverTime > 0) { hoverTime--; } else { hoverTime = 0;} }



        if (Input.GetMouseButtonUp(0)) {

            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //if (hit.collider != null) {
                clickPosX = 0;//mousePos.x;
                clickPosY = 0;//mousePos.y;
                
                //Debug.Log(lastClicked);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            //}
        }
    }


   

    //For ease of access all types of damage moves are listed here. for now
    /*
    public int CLICKED(string name){
        if (name == "Player")
            return((int)(Heal*Mult*-1));
        else
            return((int)(Pain*Mult));
    }
    */
}

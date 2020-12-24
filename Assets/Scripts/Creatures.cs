using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{
    private Clicker main;
    private SpriteRenderer Body;
    //private Creatures Player;


    //globals for the creature
    //public string name;

    public int HP;
    public int MaxHP;
    public int Armor;
    public int MagicArmor;
    
    public int MaxStrain;
    public int Strain;
    public int StrainRegen;

    public int Speed;

    public string[] Bonuses = new string[6]; // the 6 is an arbitrary number i may use a list instead later

    public int[] Pos = {0,0}; // x,y loc on grid

    bool hover = false;



    

    // Start is called before the first frame update
    void Start()
    {
        //if (gameObject.name != "Player")
        //    Player = GameObject.Find("Player").GetComponent<Creatures>();
        main = GameObject.Find("Main Camera").GetComponent<Clicker>();
        main.Click += Damage;
        main.Hover += Hover;

        Body = gameObject.GetComponent<SpriteRenderer>();

    }

    


    // Update is called once per frame
    void Update()
    {
        if (hover) {Hover();}
        
        /*
        if (gameObject.name != "Player")
            if (damageTimer == 0){
                Player.HP -= 1;
                damageTimer = damageTimerMax;
            }
            else   
                damageTimer -=1;

            


        if (Timmer == 0){
            Body.color = Color.white;
            Timmer -= 1;
        }else
            Timmer -= 1;

        if (main.clicked == gameObject.name){
            Damage();
        }
        */
    }

    void Damage(){
        if (main.selected == gameObject.name){
            Debug.Log(gameObject.name);
        }
        /*
        int damage = main.CLICKED(gameObject.name);
        HP -= damage;

        //main.State = gameObject.name;
        if (damage > 0){
            Body.color = Color.red;
            Timmer = damage/2;
        }else{
            Body.color = Color.cyan;
            Timmer = (damage*-1)/2;
        }

        if(HP <= 0){
            HP = 0;
            Destroy(gameObject);
        }
        if(HP > MaxHP)
            HP = MaxHP;
        */
    }




    void Hover() {
        if (main.hovering == gameObject.name && !hover){
            Body.color = Color.red;
            HeathGui();
            hover = true;
        } else if (main.hovering != gameObject.name && hover) {
            Body.color = Color.white;
            hover = false;
        }
    }

    
    void HeathGui() {
        int i = (int)(-0.4f * (HP + Armor + MagicArmor));
        Debug.Log(i);
        for (int a = 0; a < HP; a++){
            GameObject bab = Instantiate(main.Heart, new Vector3(i * 0.9F, 1.3f, 0), Quaternion.identity);
            bab.transform.parent = gameObject.transform;
            i++;
        }

        //for (int a = 0; a < (MaxHP - HP); a++){
        //    hpList += main.hpSprites[8];
        //}

        for (int a = 0; a < Armor; a++){
            GameObject bab = Instantiate(main.Armor, new Vector3(i * 0.9F, 1.3f, 0), Quaternion.identity);
            bab.transform.parent = gameObject.transform;
            i++;
        }

        for (int a = 0; a < MagicArmor; a++){
            GameObject bab = Instantiate(main.MagicArmor, new Vector3(i * 0.9F, 1.3f, 0), Quaternion.identity);
            bab.transform.parent = gameObject.transform;
            i++;
        }



    }
    //*/
}
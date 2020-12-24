using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creatures : MonoBehaviour
{
    private Clicker main;
    Grid grid;

    public Transform target;
	public float movespeed = 10; // this is for visuals with pathfinding
	Vector3[] path;
	int targetIndex;


    public int HP;
    public int MaxHP;
    public int Armor;
    public int MagicArmor;
    
    //public int MaxStrain;
    //public int Strain;
    //public int StrainRegen;

    //public int Speed; // number of tiles that can be moved per strain

    //public string[] Bonuses = new string[6]; // the 6 is an arbitrary number i may use a list instead later

    bool hover = false;
    bool click = false;

    


    void Start()
    {
        //if (gameObject.name != "Player")
        //    Player = GameObject.Find("Player").GetComponent<Creatures>();
        main = GameObject.Find("Main Camera").GetComponent<Clicker>();
        main.Click += Clicked;
        main.RightClick += Move;
        main.Hover += Hover;

        grid = GameObject.Find("Pathfinder").GetComponent<Grid>();

        //Body = gameObject.GetComponent<MeshRenderer>();

    }

    


    // Update is called once per frame
    void Update()
    {
        if (hover) {Hover();}
    }


    void Clicked(){
        if (main.selected) {
            if (main.selected.name == gameObject.name){
                //Debug.Log(gameObject.name);
                click = true;
            }
        }
    }


    void Move() {
        if (main.hovering) {
            if (click) {
                target.transform.position = main.hovering.transform.position + new Vector3(0,5,0);
                //Debug.Log(grid.NodeFromWorldPoint(main.hovering.transform.position));
                click = false;

                PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
            }
        }
    }



    void Hover() {
        if (main.hovering) {
            if (main.hovering.name == gameObject.name && !hover){
                //Body.color = Color.red;
                //HeathGui();
                hover = true;
            } else if (main.hovering.name != gameObject.name && hover) {
                //Body.color = Color.white;
                hover = false;
            }
        }
    }

    
    void HeathGui() {
        int i = (int)(-0.4f * (HP + Armor + MagicArmor));
        //Debug.Log(i);
        for (int a = 0; a < HP; a++){
            GameObject bab = Instantiate(main.Heart, new Vector3(i * 0.9F, 1.3f, 0), Quaternion.identity);
            bab.transform.parent = gameObject.transform;
            i++;
        }

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




    



    ////////////////////////// The below stuffs was yoinked from https://github.com/SebLague/Pathfinding ep 6 /////////////////////

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,movespeed * Time.deltaTime);
			yield return null;

		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}

    ////////////////////////// The above stuffs was yoinked from https://github.com/SebLague/Pathfinding ep 6 /////////////////////








    //*/
}









using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace clothgame{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float speed;

        [SerializeField]
        float delay;

        float[] walking;

        public Coordinates coordinates;
        public ClothController[] cloths;

        public static int money = 100;
        public int m;

        Animator anim;
        RaycastHit2D hit;

        [SerializeField]
        LayerMask obstacle;

        [SerializeField]
        LayerMask interact;

        [SerializeField]
        Vector3 v3;

        Vector3 dir;
        Vector3 pose;

        public static bool isWalk;

        void Start()
        {
            dir = new Vector2(0, -1);
            anim = GetComponent<Animator>();
            walking = new float[4];
            pose = transform.position;
            transform.position = coordinates.coord;
        }

        void Update()
        {
            Move();
            InteractCheck();
            m = money;
        }

        bool CheckCol{
            get
            {
                hit = Physics2D.Raycast(transform.position + v3, dir, 1, obstacle);

                return hit.collider != null;
            }
        }

        public void Move(){

            foreach(ClothController c in cloths){
                c.anim.SetBool("walk", isWalk);
            }

            anim.SetBool("walk", isWalk);

            if(Input.GetKey(KeyCode.W)){
                dir = new Vector2(0, 1);
                walking[0] += 1 * Time.deltaTime;
                if(transform.position == pose){
                    SetAnimParameters(0, 1);

                    if(!CheckCol && walking[0] > delay){
                        isWalk = true;
                        SetAnimParameters(0, 1);
                        pose += dir;
                    }
                }
            }else{
                walking[0] = 0;
            
            }

            if(Input.GetKey(KeyCode.S)){
                dir = new Vector2(0, -1);
                walking[1] += 1 * Time.deltaTime;
                if(transform.position == pose){
                    SetAnimParameters(0, -1);

                    if(!CheckCol && walking[1] > delay){
                        isWalk = true;
                        SetAnimParameters(0, -1);
                        pose += dir;
                    }
                }
            }else{
                walking[1] = 0;
            }

            if(Input.GetKey(KeyCode.A)){
                dir = new Vector2(-1, 0);
                walking[3] += 1 * Time.deltaTime;
                if(transform.position == pose){
                    SetAnimParameters(-1, 0);

                    if(!CheckCol && walking[3] > delay){
                        isWalk = true;
                        SetAnimParameters(-1, 0);
                        pose += dir;
                    }
                }
            }else{
                walking[3] = 0;
            
            }

            if(Input.GetKey(KeyCode.D)){
                dir = new Vector2(1, 0);
                walking[2] += 1 * Time.deltaTime;
                if(transform.position == pose){
                    SetAnimParameters(1, 0);

                    if(!CheckCol && walking[2] > delay){
                        isWalk = true;
                        SetAnimParameters(1, 0);
                        pose += dir;
                    }
                }
            }else{
                walking[2] = 0;
            }

            if(transform.position == pose){
                isWalk = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, pose, speed * Time.deltaTime);
        }

        public void InteractCheck(){

            RaycastHit2D hit = Physics2D.Raycast(transform.position + v3, dir, 1, interact);

            if(hit.collider != null){
                if(hit.collider.CompareTag("Interactable") && Input.GetKeyDown(KeyCode.Space)){
                DialogueTrigger dialogue = hit.collider.GetComponent<DialogueTrigger>();
                dialogue.TriggerDialogue();
            }

            if(hit.collider.CompareTag("Door") && Input.GetKeyDown(KeyCode.Space)){
                NextScene scene = hit.collider.GetComponent<NextScene>();
                StartCoroutine(scene.LoadLevel(scene.sceneIndex));
            }
            }
            

        }

        void OnDrawGizmos(){
            Gizmos.DrawRay(transform.position + v3, dir);
        }

        public void SetAnimParameters(float x, float y){
            anim.SetFloat("horizontal", x);
            anim.SetFloat("vertical", y);
            

            foreach(ClothController c in cloths){
                c.SetAnimatorParameters(x, y);
            }
        }
    }
}


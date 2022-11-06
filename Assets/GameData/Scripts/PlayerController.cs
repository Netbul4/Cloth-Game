using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace clothgame{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] 
        float speed;    //Move Speed of the player.

        [SerializeField]
        float delay;    //Delay to start moving.

        [SerializeField]
        GameObject interactSign; //Sign that shows player that can interact with the object.

        [SerializeField]
        LayerMask obstacle; //Obstacle Layer.

        [SerializeField]
        LayerMask interact; //Interactable Layer.

        [SerializeField]
        Vector3 v3;     //Vector for check collisions.


        float[] walking;
        public Coordinates coordinates;
        public ClothController[] cloths;

        public static int money = 100;

        Animator anim;
        RaycastHit2D hit;


        Vector3 dir;
        Vector3 pose;

        public static bool isWalk;

        public static PlayerController player;

        private void Awake() {
            if(player != null){
                Destroy(gameObject);
            }else{
                player = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
            dir = new Vector2(0, -1);
            anim = GetComponent<Animator>();
            walking = new float[4];
            pose = transform.position;
        }

        void Update()
        {
            Move();
            InteractCheck();
        }

        //This check if the player are colliding with an obstacle object.
        bool CheckCol{
            get
            {
                hit = Physics2D.Raycast(transform.position + v3, dir, 1, obstacle); //Draw a Raycast with the obstacle filter.

                return hit.collider != null;  //Returns true.
            }
        }

        public void Move(){

            foreach(ClothController c in cloths){
                c.anim.SetBool("walk", isWalk);
            }

            anim.SetBool("walk", isWalk);

            if(Input.GetKey(KeyCode.W)){
                dir = new Vector2(0, 1);
                walking[0] += 1 * Time.deltaTime;  // this add values for start walking 
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
                walking[1] += 1 * Time.deltaTime;  // this add values for start walking 
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
                walking[3] += 1 * Time.deltaTime;  // this add values for start walking 
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
                walking[2] += 1 * Time.deltaTime;  // this add values for start walking 
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

            transform.position = Vector3.MoveTowards(transform.position, pose, speed * Time.deltaTime); // Move the character.

        }

        //This check the types of interactable objects.
        public void InteractCheck(){

            RaycastHit2D hit = Physics2D.Raycast(transform.position + v3, dir, 1, interact); //Draw the same Raycast of Obstacles but filtering by Interact Layer.

            if(hit.collider != null){
                interactSign.SetActive(true);

                if(hit.collider.CompareTag("Interactable") && Input.GetKeyDown(KeyCode.Space)){
                DialogueTrigger dialogue = hit.collider.GetComponent<DialogueTrigger>(); //Launch the dialogue of the NPC/Object.
                dialogue.TriggerDialogue();
            }

            if(hit.collider.CompareTag("Door") && Input.GetKeyDown(KeyCode.Space)){
                NextScene scene = hit.collider.GetComponent<NextScene>(); // Get the Change Scenes Script.
                StartCoroutine(scene.LoadLevel(scene.sceneIndex)); //Launch the load of next scene.
            }
            }else{
                interactSign.SetActive(false);
            }
            

        }

        //This set the Animation values for the player and the clothes.
        public void SetAnimParameters(float x, float y){
            anim.SetFloat("horizontal", x);
            anim.SetFloat("vertical", y);
            

            foreach(ClothController c in cloths){
                c.SetAnimatorParameters(x, y);     //Set the parameters of each cloth holder in the character.
            }
        }
    }
}


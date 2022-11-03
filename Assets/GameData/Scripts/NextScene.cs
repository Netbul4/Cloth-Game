using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace clothgame{
    public class NextScene : MonoBehaviour
    {
        [SerializeField]
        int sceneIndex;

        [SerializeField]
        Animator anim;

        void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("Player")){
                StartCoroutine(LoadLevel(sceneIndex));
            }
        }

        IEnumerator LoadLevel(int index){
            anim.SetBool("change", true);
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene(index);
            yield return 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace clothgame{
    public class NextScene : MonoBehaviour
    {
        public int sceneIndex;

        [SerializeField]
        Animator anim;

        public IEnumerator LoadLevel(int index){
            anim.SetBool("change", true);
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene(index);
            yield return 0;
        }
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management {
    //Fade
    public class Fade : MonoBehaviour {
        private int nextScene = 0;

        //Set nextScene 
        public void SetNextScene(int idx) { nextScene = idx; }

        //End fade-in
        public void EndFadeIn() { gameObject.SetActive(false); }

        //Start fade-out
        public void StartFadeOut() { GetComponent<Animator>().SetTrigger("SetFadeOut"); }

        //End fade-out
        public void EndFadeOut() { UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene); }
    }
}

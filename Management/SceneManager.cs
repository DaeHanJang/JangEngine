using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management {
    //SceneManager
    public abstract class SceneManager<T> : MonoBehaviour where T : MonoBehaviour {
        private static T inst = null;

        protected GameObject screenTransitionEffect = null;

        public static T Inst { get { return inst; } }

        protected virtual void Awake() {
            if (inst == null) inst = gameObject.GetComponent<T>();
            else Destroy(gameObject);
        }

        //Set resolution
        public void SetResolution(int setWidth, int setHeight, bool fullScreen) {
            int deviceWidth = Screen.width, deviceHeight = Screen.height;

            Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), fullScreen);
            //기기의 해상도 비가 더 큰 경우 게임 화면의 너비가 감소
            if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) {
                float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight);
                Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
            }
            //게임의 해상도 비가 더 큰 경우 게임 화면의 높이가 감소
            else {
                float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight);
                Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
            }
        }

        //Instantiate UI version
        public GameObject InstantiateUI(string path, string cvName) {
            GameObject resource = (GameObject)Resources.Load(path);
            GameObject obj = Instantiate(resource, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find(cvName).transform, false);

            return obj;
        }
        public GameObject InstantiateUI(GameObject name, string cvName) {
            GameObject obj = Instantiate(name, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find(cvName).transform, false);

            return obj;
        }

        //Screen transition effet Instantiate
        protected void SetScreenTransitionEffect(string path, string cvName) {
            screenTransitionEffect = InstantiateUI(path, cvName);
        }

        //Load scene
        public virtual void LoadScene(int sceneIdx) {
            if (!screenTransitionEffect) SceneManager.LoadScene(sceneIdx);
        }
        public virtual void LoadScene(string sceneName) {
            if (!screenTransitionEffect) SceneManager.LoadScene(sceneName);
        }

        //Abstract method
        //Game start
        public abstract void GameStart();

        //Game over
        public abstract void GameOver();
    }
}

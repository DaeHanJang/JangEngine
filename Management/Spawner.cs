using System.Collections;
using UnityEngine;

namespace Management {
    public class Spanwer : MonoBehaviour {
        public virtual GameObject[] DistanceSpawner(int length, Vector3 distance, GameObject name, Vector3 position, Quaternion quaternion) {
            GameObject[] obj = new GameObject[length];
            for (int i = 0; i < length; i++) obj[i] = Instantiate(name, position + distance * i, quaternion);
            return obj;
        }

        public virtual GameObject[] DistanceSpawner(int length, Vector3 distance, string name, Vector3 position, Quaternion quaternion) {
            GameObject[] obj = new GameObject[length];
            GameObject pre = Resources.Load(name) as GameObject;
            for (int i = 0; i < length; i++) obj[i] = Instantiate(pre, position + distance * i, quaternion);
            return obj;
        }

        public virtual IEnumerator TimerSpawner(float timer, bool loop, GameObject name, Vector3 position, Quaternion quaternion) {
            do {
                Instantiate(name, position, quaternion);
                yield return new WaitForSeconds(timer);
            } while (loop);
        }

        public virtual IEnumerator TimerSpawner(float timer, bool loop, string name, Vector3 position, Quaternion quaternion) {
            GameObject pre = Resources.Load(name) as GameObject;
            do {
                Instantiate(pre, position, quaternion);
                yield return new WaitForSeconds(timer);
            } while (loop);
        }
    }
}
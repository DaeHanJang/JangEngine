using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management {
    public abstract class ScreenTransitionEffect : MonoBehaviour {
        public int sceneIdx = -1;

        public abstract void StartEffectFirst();

        public abstract void StartEffectLast();

        public abstract void EndEffectFirst();

        public abstract void EndEffectLast();
    }
}

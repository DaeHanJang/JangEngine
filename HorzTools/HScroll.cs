using UnityEngine;

namespace HorzTools {
    //belt scroll tools
    public class HScroll : MonoBehaviour {
        private Rigidbody2D rb;

        protected virtual void Awake() {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        //start scroll
        public void SetStart(float speed) { rb.velocity = new Vector2(-speed, 0f); }

        //stop scroll
        public void SetStop() { rb.velocity = Vector2.zero; }
    }
}
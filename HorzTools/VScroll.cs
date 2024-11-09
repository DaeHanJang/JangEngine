using UnityEngine;

namespace HorzTools {
    //vertical scroll tools
    public class VScroll : MonoBehaviour {
        private Rigidbody2D rb;

        protected virtual void Awake() {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        //start scroll
        public void SetStart(float speed) { rb.velocity = new Vector2(0f, -speed); }

        //stop scroll
        public void setStop() { rb.velocity = Vector2.zero; }
    }
}
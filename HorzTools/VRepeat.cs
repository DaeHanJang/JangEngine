using UnityEngine;

namespace HorzTools {
    //vertical scroll repeat tools
    public class VRepeat : MonoBehaviour {
        private BoxCollider2D box;
        private float hLength; //세로 길이

        //box collider 초기화
        public void SetBoxCollider() {
            box = GetComponent<BoxCollider2D>();
            hLength = box.size.y;
        }

        //object transform update
        public void UpdateObject() {
            if (transform.position.y < -hLength) {
                Vector3 addPos = new Vector3(0, 2 * hLength, 0);
                transform.position = transform.position + addPos;
            }
        }
    }
}
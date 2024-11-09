using UnityEngine;

namespace HorzTools {
    //belt scroll repeat tools
    public class HRepeat : MonoBehaviour {
        private BoxCollider2D box;
        private float wLength; //���� ����

        //box collider �ʱ�ȭ
        public void SetBoxCollider() {
            box = GetComponent<BoxCollider2D>();
            wLength = box.size.x;
        }

        //object transform update
        public void UpdateObject() {
            if (transform.position.x < -wLength) {
                Vector3 addPos = new Vector3(2 * wLength, 0, 0);
                transform.position = transform.position + addPos;
            }
        }
    }
}
using UnityEngine;

namespace ObjectTools {
    public class Object2D : MonoBehaviour {
        private int hp;
        private int unitIdx; //식별 값
        protected float speed;
        protected float curveSpeed;

        public int HP {
            get { return hp; }
            set { hp = value; }
        }
        public int UnitIdx {
            get { return unitIdx; }
            set { unitIdx = value; }
        }
        public float Speed {
            get { return speed; }
            set { speed = value; }
        }
        public float CurveSpeed {
            get { return curveSpeed; }
            set { curveSpeed = value; }
        }

        protected virtual void DestroyObject() { Destroy(gameObject); }

        //3점 베지어 곡선
        protected Vector3 BezierCurve(Vector3 p1, Vector3 p2, Vector3 p3, float value) {
            Vector3 q1 = Vector3.Lerp(p1, p2, value);
            Vector3 q2 = Vector3.Lerp(p2, p3, value);

            Vector3 r1 = Vector3.Lerp(q1, q2, value);

            return r1;
        }

        //4점 베지어 곡선
        protected Vector3 BezierCurve(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float value) {
            Vector3 q1 = Vector3.Lerp(p1, p2, value);
            Vector3 q2 = Vector3.Lerp(p2, p3, value);
            Vector3 q3 = Vector3.Lerp(p3, p4, value);

            Vector3 r1 = Vector3.Lerp(q1, q2, value);
            Vector3 r2 = Vector3.Lerp(q2, q3, value);

            Vector3 s1 = Vector3.Lerp(r1, r2, value);

            return s1;
        }

        //베지어 곡선
        protected Vector3 BezierCurve(Vector3[] p, float value) {
            int len = p.Length;
            for (int i = len - 1; i > 0; i--) {
                for (int j = 0; j < i; j++) p[j] = Vector3.Lerp(p[j], p[j + 1], value);
            }
            return p[0];
        }

        protected void SetAngle(Vector3 target) {
            Vector3 direction = transform.position - target;
            Vector3 quaternionToTarget = Quaternion.Euler(0, 0, -180) * direction;
            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: quaternionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100f);
        }

        protected void SetSigleAngle(Vector3 target) {
            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: target);
            transform.rotation = targetRotation;
        }
    }
}

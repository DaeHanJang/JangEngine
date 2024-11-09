namespace Logic {
    //다양한 콘텐츠 Logic의 기본 Class
    public class LogicBase {
        protected const int ERROR = -1; //에러 상수
        protected const int EMPTY = 0; //공백 상수

        private int mCheckValue = 0; //연속성을 체크해야 할 값

        //mCheckValue 쓰기 전용 프로퍼티(Property)
        protected int CheckValue {
            set { mCheckValue = value; }
        }

        //mCheckValue와 같은 값이 연속된 만큼 외부 변수(_length) 증가
        protected bool isSequential(int _data, ref int _length) {
            if (_data == mCheckValue) {
                _length++;
                return true;
            }
            else return false;
        }
    }
}

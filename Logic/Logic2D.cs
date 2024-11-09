namespace Logic {
    //2차원 콘텐츠 Logic의 기본 Class
    public abstract class Logic2D : LogicBase {
        //pair class
        protected class Pair<F, S> {
            private F first;
            private S second;

            //생성자(Constructor)
            public Pair() { }
            public Pair(F f, S s) {
                first = f;
                second = s;
            }

            //first 프로퍼티(Property)
            public F First {
                get { return first; }
                set { first = value; }
            }
            //second 프로퍼티(Property)
            public S Second {
                get { return second; }
                set { second = value; }
            }
        }

        private const int DATASIZE = 100; //mPoints 크기

        //2차원 방향 상수 열거
        protected enum Direction {
            U,  //Up
            UR, //UpRight
            R,  //Right
            DR, //DownRight
            D,  //Down
            DL, //DownLeft
            L,  //Left
            UL  //UpLeft
        }
        //2차원 커서 이동 방향
        protected readonly int[,] mCursorMove = new int[,] {
        { -1, 0 },  //Up
        { -1, 1 },  //UpRight
        { 0, 1 },   //Right
        { 1, 1 },   //DownRight
        { 1, 0 },   //Down
        { 1, -1 },  //DownLeft
        { 0, -1 },  //Left
        { -1, -1 }  //UpLeft
    };

        private int[,] mDat; //2차원 데이터 배열
        private int mRow, mCol; //mDat의 행, 열

        protected int mTurn; //턴 정보
        protected int mLength; //분석할 기준 값과 대상간의 값이 같은 연속된 길이
        protected Pair<int, int>[] mPoints; //분석할 대상의 위치 정보

        //mDat[r, c]에서 정보를 분석하는 추상 함수(자식 클래스에서 재정의 강제)
        protected abstract bool analyze(int r, int c);

        //mTurn 읽기 전용 프로퍼티(Property)
        public int Turn {
            get { return mTurn; }
        }
        //mLength 읽기 전용 프로퍼티(Property)
        public int Length {
            get { return mLength; }
        }

        //생성자(Constructor)
        public Logic2D(int r, int c) {
            mRow = r;
            mCol = c;
            initData();
        }

        //내부 멤버 변수 초기화
        protected void initData() {
            mDat = new int[mRow, mCol];
            mTurn = 1;
            mLength = 0;
            mPoints = new Pair<int, int>[DATASIZE];
            for (int i = 0; i < mPoints.Length; i++) mPoints[i] = new Pair<int, int>();
        }

        //mDat[sr, sc]부터 dir 방향으로 cv값의 연속성 위치 저장 및 분석
        protected bool analyzeDirection(int cv, int dir, int sr, int sc) {
            CheckValue = cv;
            for (int r = sr, c = sc; (0 <= r && r < mRow) && (0 <= c && c < mCol); r += mCursorMove[dir, 0], c += mCursorMove[dir, 1]) {
                if (r == sr && c == sc) continue;

                if (!isSequential(mDat[r, c], ref mLength)) return mDat[r, c] == EMPTY; //연속되지 않은 데이터위치를 공백과 비교 후 반환
                //연속되는 데이터 저장
                else {
                    int index = mLength - 1;
                    mPoints[index].First = r;
                    mPoints[index].Second = c;
                }
            }
            return true;
        }

        //mDat[r, c] 데이터가 비었는지 확인
        protected bool isEmpty(int r, int c) { return mDat[r, c] == EMPTY; }

        //mLength 초기화
        protected void resetLength() { mLength = 0; }

        //mDat[r, c] 데이터 쓰기
        protected void setValue(int value, int r, int c) { mDat[r, c] = value; }

        //mDat[r, c] 데이터 읽기
        public int getValue(int r, int c) { return mDat[r, c]; }

        //mDat 읽기
        public int[,] getData() { return mDat; }

        //턴 변경
        public void nextTurn() { mTurn = 3 - mTurn; }

        //mPoints[index] 데이터 읽기
        public int getPoints(int pos, int index) {
            if (pos == 0) return mPoints[index].First;
            else return mPoints[index].Second;
        }
    }
}

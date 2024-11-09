using System.Collections.Generic;

namespace Logic {
    //오셀로 Logic Class
    public class LogicOthello : Logic2D {
        //생성자(Constructor)
        public LogicOthello(int r, int c) : base(r, c) {
            setValue(1, 3, 4);
            setValue(1, 4, 3);
            setValue(2, 3, 3);
            setValue(2, 4, 4);
        }

        //(r, c) 기준 오셀로 규칙 분석
        protected override bool analyze(int r, int c) {
            int checkvalue = 3 - mTurn; //분석 기준 값(다른 턴 플레이어)
            resetLength();

            //8방향의 뒤집혀야할 위치를 분석, 저장
            for (Direction dir = Direction.U; dir <= Logic2D.Direction.UL; dir++) {
                int beforeLength = mLength;
                if (analyzeDirection(checkvalue, (int)dir, r, c)) mLength = beforeLength;
            }
            if (mLength > 0) {
                for (int i = 0; i < mLength; i++) setValue(mTurn, mPoints[i].First, mPoints[i].Second);
                return true;
            }

            return false;
        }

        //(r, c)에 돌 놓기
        public bool setData(int r, int c) {
            if (!isEmpty(r, c)) return false; //(r, c)에 돌이 있을 경우 false
            if (!analyze(r, c)) return false;

            setValue(mTurn, r, c);
            nextTurn();

            return true;
        }

        //놓울 수 있는 장소 분석
        public bool canStoneAnalyze(ref List<KeyValuePair<int, int>> p) {
            p.Clear();
            bool chk = false;
            for (int i = 0; i < getData().GetLength(0); i++) {
                for (int j = 0; j < getData().GetLength(1); j++) {
                    if (getValue(i, j) == mTurn) {
                        for (Direction dir = Direction.U; dir <= Logic2D.Direction.UL; dir++) {
                            resetLength();
                            analyzeDirection(3 - mTurn, (int)dir, i, j);
                            if (mLength > 0) {
                                int row = mPoints[mLength - 1].First + mCursorMove[(int)dir, 0], col = mPoints[mLength - 1].Second + mCursorMove[(int)dir, 1];
                                if (0 <= row && row < getData().GetLength(0) && 0 <= col && col < getData().GetLength(1) && getValue(row, col) == 0) {
                                    setValue(3, row, col);
                                    p.Add(new KeyValuePair<int, int>(row, col));
                                    chk = true;
                                }
                            }
                        }
                    }
                }
            }
            resetLength();
            return chk;
        }

        //놓을 수 있는 장소 분석 초기화
        public void deleteCanStone() {
            for (int i = 0; i < getData().GetLength(0); i++) {
                for (int j = 0; j < getData().GetLength(1); j++) {
                    for (Direction dir = Direction.U; dir <= Logic2D.Direction.UL; dir++) {
                        if (getValue(i, j) == 3) setValue(0, i, j);
                    }
                }
            }
        }
    }
}

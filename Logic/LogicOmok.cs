using System.Collections.Generic;

namespace Logic {
    //오목 Logic Class
    public class LogicOmok : Logic2D {
        //생성자(Constructor)
        public LogicOmok(int r, int c) : base(r, c) { }

        //(r, c) 기준 오목 규칙 분석
        protected override bool analyze(int r, int c) {
            int checkvalue = mTurn; //분석 기준 값(현재 턴 플레이어)

            for (Direction dir = Direction.U; dir <= Logic2D.Direction.DR; dir++) {
                analyzeDirection(checkvalue, (int)dir, r, c);
                analyzeDirection(checkvalue, (int)dir + 4, r, c); //dir의 반대 방향 분석

                if (mLength >= 4) return true; //(r, c)를 기준으로 옆에 연속된 값이 4이상일 경우(기준값을 포함하면 5이상임으로 승리)
                resetLength();
            }

            return false;
        }

        //(r, c)에 돌 놓기
        public bool setData(int r, int c) {
            if (!isEmpty(r, c)) return false; //(r, c)에 돌이 있을 경우

            bool res = analyze(r, c);
            setValue(mTurn, r, c);
            nextTurn();

            return res;
        }

        //간단한 IA Logic
        public void subAnalyze(ref List<KeyValuePair<int, int>>[] p, int t, int r, int c) {
            List<KeyValuePair<int, int>> temp = new List<KeyValuePair<int, int>>();
            for (Direction dir = Direction.U; dir <= Logic2D.Direction.DR; dir++) {
                analyzeDirection(t, (int)dir, r, c);
                if (mLength == 0) {
                    if (getValue(r + mCursorMove[(int)dir, 0], c + mCursorMove[(int)dir, 1]) == 0)
                        temp.Add(new KeyValuePair<int, int>(r + mCursorMove[(int)dir, 0], c + mCursorMove[(int)dir, 1]));
                }
                else if (getValue(mPoints[mLength - 1].First + mCursorMove[(int)dir, 0], mPoints[mLength - 1].Second + mCursorMove[(int)dir, 1]) == 0)
                    temp.Add(new KeyValuePair<int, int>(mPoints[mLength - 1].First + mCursorMove[(int)dir, 0], mPoints[mLength - 1].Second + mCursorMove[(int)dir, 1]));

                analyzeDirection(t, (int)dir + 4, r, c);
                if (mLength == 0) {
                    if (getValue(r + mCursorMove[(int)dir + 4, 0], c + mCursorMove[(int)dir + 4, 1]) == 0)
                        temp.Add(new KeyValuePair<int, int>(r + mCursorMove[(int)dir + 4, 0], c + mCursorMove[(int)dir + 4, 1]));
                }
                else if (getValue(mPoints[mLength - 1].First + mCursorMove[(int)dir + 4, 0], mPoints[mLength - 1].Second + mCursorMove[(int)dir + 4, 1]) == 0)
                    temp.Add(new KeyValuePair<int, int>(mPoints[mLength - 1].First + mCursorMove[(int)dir + 4, 0], mPoints[mLength - 1].Second + mCursorMove[(int)dir + 4, 1]));

                if (mLength >= 3) p[3].AddRange(temp);
                else if (mLength >= 2) p[2].AddRange(temp);
                else if (mLength >= 1) p[1].AddRange(temp);
                else if (mLength >= 0) p[0].AddRange(temp);
                resetLength();
                temp.Clear();
            }
        }
    }
}

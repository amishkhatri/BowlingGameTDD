using System;
using System.Collections.Generic;

namespace xp.tdd.bowling.game.service
{

    public class Frame
    {
        private int _frameTotalScore;

        public int FrameTotalScore
        {
            get { return _frameTotalScore; }
            set { _frameTotalScore = value; }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }


        private List<Roll> _rolls;

        public List<Roll> Rolls
        {
            get { return _rolls; }
            set { _rolls = value; }
        }



    }
}

using System.Collections.Generic;
using System.Linq;

namespace xp.tdd.bowling.game.service
{

    public class BowlingGame
    {

        #region Properties

        List<KeyValuePair<int, int>> _frames = new List<KeyValuePair<int, int>>();

        /*
         *  (1,8)
         *  (1,5)
         * (2,3)
         * (2,10)
         * 
         * */


        public List<KeyValuePair<int, int>> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }





        public int GetTotalScore()
        {
            int totalScore = 0;

            foreach (KeyValuePair<int, int> item in Frames)
                totalScore += item.Value;

            return totalScore;
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int RollScore
        {
            get
            {
                System.Random randomScore = new System.Random();
                return randomScore.Next(GameConfiguration.MIN_FRAME_LIMIT, (GameConfiguration.MAX_FRAME_LIMIT + 1));
            }
        }

        #endregion

        #region Methods

        // find the last frame number
        public int GetCurrentFrameNumber() 
        {
            int currentFrames = 0;

            currentFrames = Frames.Count >0 ? Frames.Max(x => x.Key) : 0;
            
            return currentFrames;

        }

        public bool CanAddNewFrame(int framenumber)
        {
            return framenumber <= GameConfiguration.MAX_FRAME_LIMIT;
            //    return GetCurrentFrameNumber() <= GameConfiguration.MAX_FRAME_LIMIT;

        }

        //validation
        public bool CanAddNewRoll(int framenumber)
        {
            int countTotalRolls=0;
                        
            foreach (KeyValuePair<int, int> item in Frames)
            {
                if (item.Key == framenumber)
                {
                    countTotalRolls++;
                }
                    
            }

            return countTotalRolls <= GameConfiguration.MAX_ROLL_LIMIT;

        }

        public bool IsLegitimateScore(int inputScore)
        {
            return inputScore <= GameConfiguration.MAX_ROLL_SCORE;
        }


        public int GetScoreByFrame(int FrameNumber)
        {
            int totalScore = 0;

            foreach (KeyValuePair<int, int> item in Frames)
            {
                if (item.Key == FrameNumber)
                {
                    totalScore += item.Value;
                }

            }


            return totalScore;

        }

        
        public bool CreateRoll(int FrameNumber, int NewRollScore)
        {
            bool success = false;

            try
            {
                if (CanAddNewFrame(FrameNumber))
                {
                    if (IsLegitimateScore(NewRollScore))
                    {
                        //  var currentFrame = GetCurrentFrameNumber();

                        if (CanAddNewRoll(FrameNumber))
                        {
                            if (Frames.Count > 0)
                                Frames.Add(new KeyValuePair<int, int>(FrameNumber, NewRollScore));
                            else
                                Frames.Add(new KeyValuePair<int, int>(1, NewRollScore));

                            success = true;

                        }

                    }
                }
    
            }
            catch(System.Exception ex)
            {
                throw ex;
            }

            return success;
        }

        #endregion



    }
}
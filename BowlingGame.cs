using System.Collections.Generic;
using System.Linq;

namespace xp.tdd.bowling.game.service
{

    public partial class BowlingGame
    {
       
        #region Properties

        private List<Frame> _frames = new List<Frame>(GameConfiguration.MAX_FRAME_LIMIT);

        public List<Frame> Frames
        {
            get { return _frames; }
            set { _frames = value; }
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
        

        public bool HasFrameMaxOut()
        {
            return Frames.Count >= GameConfiguration.MAX_FRAME_LIMIT;
        }

        public bool HasRollMaxOut(Frame frame)
        {
            return frame.Rolls.Count >= GameConfiguration.MAX_ROLL_LIMIT;
        }

        public bool IsLegitimateScore(int inputScore)
        {
            return inputScore <= GameConfiguration.MAX_ROLL_SCORE;
        }

        public int GetScoreByFrame(int FrameNumber)
        {
            int totalScore = 0;

            var frame = this.Frames.FirstOrDefault(s => s.Number == FrameNumber);

            if (frame != null)
            {
                foreach (Roll roll in frame.Rolls)
                    totalScore += roll.Score;
            }

            return totalScore;

        }


        public int GetTotalScore()
        {
            int totalScore = 0;

            //try
            //{
            //    //totalScore = this.Frames.Count;
            if (Frames != null)
            {
                for (int i = 0; i < Frames.Count; i++)
                {
                    if (Frames[i].Rolls != null)
                    {
                        for (int j = 0; j < Frames[i].Rolls.Count; j++)
                        {
                            totalScore = totalScore + Frames[i].Rolls[j].Score;
                        }
                    }
                }
            }

                //foreach (var frame in this.Frames)
                //    foreach (var item in frame.Rolls)
                //        totalScore += item.Score;
            //}
            //catch (System.Exception ex)
            //{
            //    throw ex;
            //}

            return totalScore;

        }

        public bool AddFrame(int FrameNumber)
        {
            bool result = false;

            try
            {
                if (!HasFrameMaxOut())
                {
                    Frame frame = new Frame();
                    frame.Number = FrameNumber;
                    frame.FrameTotalScore = GetScoreByFrame(FrameNumber);
                    this.Frames.Add(frame);
                    result = true;
                }
                else
                    Message = "The game has only 10 frames";
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return result;
        }
                
        public bool AddRoll(int FrameNumber, int RollNumber,int NewRollScore)
        {
            bool success = false;

            try
            {

                if (!IsLegitimateScore(NewRollScore))
                {
                    Message = "Invalid Roll Score.";
                    return false;
                }

                Roll roll = new Roll()
                {
                    Number = RollNumber,
                    Score = NewRollScore
                };

                Frame foundFrame = this.Frames.FirstOrDefault(s => s.Number == FrameNumber);

                //existing frame
                if (foundFrame != null)
                {
                    if (!HasRollMaxOut(foundFrame))
                    {
                        foundFrame.Rolls.Add(roll);
                        success = true;
                    }
                    else                    
                    {
                        Message = "Failed to add a new roll.";
                    }
                }                    
                else //no frame
                {
                    var frameScore = GetScoreByFrame(FrameNumber);
                    Frame frame = new Frame();
                    frame.Number = FrameNumber;
                    frame.FrameTotalScore = frameScore == 0 ? roll.Score : frameScore;
                    frame.Rolls = new List<Roll>() { roll };
                    this.Frames.Add(frame);
                    success = true;                                        
                }
                                

            }
            catch (System.Exception ex)
            {
                success = false;
                throw ex;
            }

            return success;
        }

        

        #endregion



    }
}
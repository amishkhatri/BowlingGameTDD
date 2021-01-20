using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace xp.tdd.bowling.game.service.test
{
    public class BowlingGameServiceTest
    {
        #region "Constant"

            public const int ROLL_1 = 1;
            public const int ROLL_2 = 2;
            public const int FRAME_1 = 1;
            public const int FRAME_2 = 2;
            public const int FRAME_3 = 3;
            public const int FRAME_4 = 4;
            public const int FRAME_5 = 5;
            public const int FRAME_6 = 6;
            public const int FRAME_7 = 7;
            public const int FRAME_8 = 8;
            public const int FRAME_9 = 9;
            public const int FRAME_10 = 10;

        #endregion


        BowlingGame game;

        [OneTimeSetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        #region "Acceptance Criteria"

            //Acceptance Criteria:
            //1.A game should have 10 frames.
            //2.Each frame would have max of 2 rolls to knock down 10 pins.
            //3.The total score of a frame should be sum of pins knocked in 2 rolls plus score till last frame.
            //4.Last frame shows the total score of the game.
            //5. Game should not allow to play game after 10th frame as its end of the game.

        #endregion


        //Sprint 1  AC 1
        [Test]
        public void Should_Return_Success_When_Only_10_Frames_Present()
        {
            //Arrange
            bool result;
            int TotalUsedFrames = 0;
            TotalUsedFrames = game.GetCurrentFrameNumber();

            //Act
            result = (TotalUsedFrames <= GameConfiguration.MAX_FRAME_LIMIT);

            //Assert
            Assert.AreEqual(true, result);
        }


        //Sprint 1  AC 2
        [Test]
        public void Should_Return_Success_When_Add_New_Roll_1_In_Frame_1()
        {
            //Arrange
            bool result;

            //Act
            result = game.CreateRoll(FRAME_1, 10);

            Console.WriteLine("Count Roll 1 " + game.Frames.Count);

            //Assert
            Assert.AreEqual(true, result);

        }

        //Sprint 1  AC 2
        [Test]
        public void Should_Return_Success_When_Add_New_Roll_2_In_Frame_1()
        {
            //Arrange
            bool result;

            Console.WriteLine("before roll 2 " + game.Frames.Count);

            //Act
            result = game.CreateRoll(FRAME_1, 10);

            Console.WriteLine("after roll 2- " + game.Frames.Count);

            //Assert
            Assert.AreEqual(true, result);

        }


        //Sprint 1  AC 2
        [Test]
        public void Should_Return_Success_When_Add_New_Roll_3_In_Frame_1()
        {
            //Arrange
            bool result;

            //Act
            Console.WriteLine(game.GetCurrentFrameNumber().ToString());

            result = game.CreateRoll(FRAME_1, 8);

            //Assert
            Assert.AreEqual(false, result);

        }

        //Sprint 1  AC 3        
        [Test]
        public void Should_Return_Success_To_Calculate_Cumulative_Score()
        {

            //Arrange
            int TotalScore;
            bool result1, result2;

            //Act
            result1 = game.CreateRoll(FRAME_3, 10);
            result2 = game.CreateRoll(FRAME_3, 10);

            result1 = game.CreateRoll(FRAME_4, 10);
            result2 = game.CreateRoll(FRAME_4, 10);

            TotalScore = game.GetTotalScore();

            //Assert
            Assert.AreEqual(40, TotalScore);

        }

        //Sprint 1  AC 3        
        [Test]
        public void Should_Return_Fail_When_Add_More_Than_10_Frames()
        {

            //Arrange
            bool result;

            //Act
            result = game.CreateRoll(11, 5);

            //Assert
            Assert.AreEqual(false, result);

        }

        //Sprint 1  AC 3        
        [Test]
        public void Should_Return_Success_To_Calculate_Cumulative_Score_By_Frame()
        {

            //Arrange
            int TotalScore;
            bool result1, result2;

            //Act
            result1 = game.CreateRoll(FRAME_10, 10);
            result2 = game.CreateRoll(FRAME_10, 10);

            TotalScore = game.GetScoreByFrame(FRAME_10);

            //Assert
            Assert.AreEqual(20, TotalScore);


        }


    }
}
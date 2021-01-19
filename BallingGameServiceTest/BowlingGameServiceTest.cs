using NUnit.Framework;

namespace xp.tdd.bowling.game.service.test
{
    public class BowlingGameServiceTest
    {
     
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


        BowlingGame game;

        [OneTimeSetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        [Test]
        public void Should_Return_Success_When_Add_New_Frame_1()
        {
            //Arrange
            bool result;

            //Act
            result = game.AddFrame(FRAME_2);

            //Assert
            Assert.AreEqual(true, result);

        }

        [Test]
        public void Should_Return_Success_When_Add_New_Roll_1_In_Frame_1()
        {
            //Arrange
            bool result;

            //Act
            result = game.AddRoll(FRAME_1, ROLL_1,5);

            //Assert
            Assert.AreEqual(true, result);

        }


        [Test]
        public void Should_Return_Success_When_Add_New_Roll_2_In_Frame_1()
        {
            //Arrange
            bool result;

            //Act
            result = game.AddRoll(FRAME_1, ROLL_2, 9);

            //Assert
            Assert.AreEqual(true, result);

        }

        [Test]
        public void Should_Return_Fail_When_Add_New_Roll_With_More_Than_10_Score()
        {
            //Arrange
            int score = 11;

            //Act
            var result = game.AddRoll(FRAME_1, ROLL_1, score);

            //Assert
            Assert.IsFalse(result);

        }


        
        [Test]
        public void Should_Return_Success_When_Calculate_Total_Score()
        {
            // Arrange
            int rgkscore;

            //Act
            rgkscore = game.GetTotalScore();

            //Assert 
            Assert.NotZero(rgkscore);
            //Assert.IsTrue(rgkscore > 0);
        }

        



    }
}
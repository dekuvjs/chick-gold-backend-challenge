using WaterJugChallenge.Helpers;
using WaterJugChallenge.Models;
using Xunit;


namespace Tests
{
    public class WaterJugHelperTest
    {
        [Fact]
        public void ShouldReturnFalseWhenNegativeValues()
        {
            Assert.False(WaterJugHelper.CheckIfPossible(-4, 3, 2));
            Assert.False(WaterJugHelper.CheckIfPossible(4, -3, 2));
            Assert.False(WaterJugHelper.CheckIfPossible(4, 3, -2));
        }

        [Fact]
        public void ShouldReturnFalseWhenAmountWantedGreaterThanBuckets()
        {
            Assert.False(WaterJugHelper.CheckIfPossible(4, 3, 6));
        }

        [Fact]
        public void ShouldReturnTrueWhenRiddleIsSolvable()
        {
            Assert.True(WaterJugHelper.CheckIfPossible(4, 3, 2));
            Assert.True(WaterJugHelper.CheckIfPossible(5, 3, 4));
            Assert.True(WaterJugHelper.CheckIfPossible(7, 5, 3));
        }

        [Fact]
        public void ShouldSolveRiddleWithCorrectSteps()
        {
            var steps = WaterJugHelper.SolveRiddle(4, 3, 2, "X", "Y");
            Assert.NotNull(steps);
            Assert.NotEmpty(steps);
            Assert.Equal("Solved", steps[^1].Status);
        }

        [Fact]
        public void ShouldSolveRiddleWithYAsFirstBucket()
        {
            var steps = WaterJugHelper.SolveRiddle(4, 3, 2, "Y", "X", true);
            Assert.NotNull(steps);
            Assert.NotEmpty(steps);
            Assert.Equal("Solved", steps[^1].Status);
        }

        [Fact]
        public void ShouldGenerateCorrectStepNumbers()
        {
            var steps = WaterJugHelper.SolveRiddle(4, 3, 2, "X", "Y");
            for (int i = 0; i < steps.Count; i++)
            {
                Assert.Equal(i + 1, steps[i].StepNumber);
            }
        }

        [Fact]
        public void ShouldContainValidActions()
        {
            var steps = WaterJugHelper.SolveRiddle(4, 3, 2, "X", "Y");
            foreach (var step in steps)
            {
                Assert.Contains(step.Action, new[] {
                    "Fill bucket X",
                    "Fill bucket Y",
                    "Throw water from bucket X",
                    "Throw water from bucket Y",
                    "Transfer water from bucket X to bucket Y",
                    "Transfer water from bucket Y to bucket X"
                });
            }
        }

        [Fact]
        public void ShouldMaintainValidWaterAmounts()
        {
            var steps = WaterJugHelper.SolveRiddle(4, 3, 2, "X", "Y");
            foreach (var step in steps)
            {
                Assert.True(step.BucketX >= 0 && step.BucketX <= 4);
                Assert.True(step.BucketY >= 0 && step.BucketY <= 3);
            }
        }
    }
}
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
		[Test]
		public void Dummy_LosesHealthIfAttacked()
		{
			// Arrange
			Dummy dummy = new Dummy(10, 10);

			// Act
			dummy.TakeAttack(3); // Assuming 3 damage

			// Assert
			Assert.That(dummy.Health, Is.EqualTo(7), "Dummy health doesn't decrease after attack.");
		}

		[Test]
		public void DeadDummy_ThrowsExceptionIfAttacked()
		{
			// Arrange
			Dummy deadDummy = new Dummy(10, 10);

			// Assert & Act
			Assert.Throws<System.InvalidOperationException>(() => deadDummy.TakeAttack(5),
				"Attacking a dead dummy should throw an exception.");
		}

		[Test]
		public void DeadDummy_CanGiveXP()
		{
			// Arrange
			Dummy deadDummy = new Dummy(10, 8);

			// Act
			int xp = deadDummy.GiveExperience();

			// Assert
			Assert.That(xp, Is.EqualTo(10), "Dead dummy doesn't give the correct amount of XP.");
		}

		[Test]
		public void AliveDummy_CantGiveXP()
		{
			// Arrange
			Dummy aliveDummy = new Dummy(10, 10);

			// Assert & Act
			Assert.Throws<System.InvalidOperationException>(() => aliveDummy.GiveExperience(),
				"Alive dummy shouldn't be able to give XP.");
		}

	}
}
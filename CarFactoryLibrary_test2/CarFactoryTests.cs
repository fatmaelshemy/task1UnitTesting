using CarFactoryLibrary;

namespace CarFactoryLibrary_test2
{
    public class CarFactoryTests
    {
        [Fact]
        public void IsStopped_velocity0_true()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 0;

            // Act
            bool result = bmw.IsStopped();

            // Boolean Asserts
            Assert.True(result);
        }
        [Fact]
        public void IncreaseVelocity_valocity10Add20_30()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 10;
            double AddedVelocitoy = 20;
            // Act
            bmw.IncreaseVelocity(AddedVelocitoy);
            // Numeric Asserts
            Assert.False(bmw.velocity < 10);//30

            Assert.InRange(bmw.velocity, 20, 30);
        }
        [Fact]
        public void GetDirection_DirectionForward_Forward()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Forward;

            // Act
            string result = bmw.GetDirection();

            // string Asserts
            Assert.Equal(DrivingMode.Forward.ToString(), result);

            Assert.StartsWith("F", result);
            Assert.EndsWith("rd", result);

            Assert.Contains("wa", result);
            Assert.DoesNotContain("zx", result);

            Assert.Matches("[A-Z][a-z]*rd", result);

            Assert.DoesNotMatch("[0-9]", result);

        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.Same(bmw, car);
            Assert.NotSame(bmw2, car);
        }
        [Fact]
        public void NewCar_CarTypeBMW_BMW()
        {


            // Act
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            // Type Asserts
            Assert.IsType<BMW>(car);
            Assert.IsNotType<Toyota>(car);

            Assert.IsAssignableFrom<Car>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
            Assert.IsAssignableFrom<Car>(new Toyota());
        }
        [Fact]
        public void NewCar_CarTypeHonda_Exception()
        {
            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}

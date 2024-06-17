namespace LaptopDiscount.nUnitTests;

public class EmployeeDiscountTests
{
    private LaptopDiscount _laptopDiscount;

    [SetUp]
    public void SetUp()
    {
        _employeeDiscount = new EmployeeDiscount();
    }

    private void SetupEmployeeDiscount(LaptopDiscount employeeType, decimal price)
    {
        _employeeDiscount.EmployeeType = employeeType;
        _employeeDiscount.Price = price;
    }

    [Test]
    public void CalculateDiscountedPrice_PartTimeEmployee_ShouldReturnOriginalPrice()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.PartTime, 1000);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(1000, result);
    }

    [Test]
    public void CalculateDiscountedPrice_PartialLoadEmployee_ShouldApply5PercentDiscount()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.PartialLoad, 1000);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(950, result);
    }

    [Test]
    public void CalculateDiscountedPrice_FullTimeEmployee_ShouldApply10PercentDiscount()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.FullTime, 1000);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(900, result);
    }

    [Test]
    public void CalculateDiscountedPrice_CompanyPurchasingEmployee_ShouldApply20PercentDiscount()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.CompanyPurchasing, 1000);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(800, result);
    }

    [Test]
    public void CalculateDiscountedPrice_PartTimeEmployeeWithZeroPrice_ShouldReturnZero()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.PartTime, 0);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void CalculateDiscountedPrice_FullTimeEmployeeWithNegativePrice_ShouldApply10PercentDiscount()
    {
        // Arrange
        SetupEmployeeDiscount(EmployeeType.FullTime, -100);

        // Act
        var result = _employeeDiscount.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(-90, result);
    }
}

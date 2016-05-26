// <copyright file="MyIOCTests.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  using MyIOC;
  using Xunit;

  /// <summary>
  /// the main test class
  /// </summary>
  public class MyIOCTests
  {
    /// <summary>
    /// the main test for my composition container
    /// </summary>
    [Fact]
    public void TestCompositionWithStatic()
    {
      string staticString = "new data";
      Container container = new Container();
      container.Register<LegacyPart, ILegacyPart>();
      container.Register<DataAccess, IDataAccess>();
      container.Register<LogicLayer, ILogicLayer>();
      container.Register<TestController, ITestController>();
      container.Register<StaticPeice, IStaticPiece>(Lifetime.Singleton);
      container.RegisterValue("connection", "Some Connection String");
      TestController controller = container.Resolve<TestController>();
      controller.SetStaticData(staticString);
      controller = container.Resolve<TestController>();
      Assert.True(controller.GetStaticData() == staticString);
    }

    /// <summary>
    /// the main test for my composition container
    /// </summary>
    [Fact]
    public void TestCompositionWithTransient()
    {
      string staticString = "new data";
      Container container = new Container();
      container.Register<LegacyPart, ILegacyPart>();
      container.Register<DataAccess, IDataAccess>();
      container.Register<LogicLayer, ILogicLayer>();
      container.Register<TestController, ITestController>();
      container.Register<StaticPeice, IStaticPiece>(Lifetime.Transient);
      container.RegisterValue("connection", "Some Connection String");
      TestController controller = container.Resolve<TestController>();
      controller.SetStaticData(staticString);
      controller = container.Resolve<TestController>();
      Assert.True(controller.GetStaticData() != staticString);
    }

    /// <summary>
    /// test for errors
    /// </summary>
    [Fact]
    public void TestMissingPieces()
    {
      Container container = new Container();
      container.Register<DataAccess, IDataAccess>();
      container.Register<LogicLayer, ILogicLayer>();
      container.Register<TestController, ITestController>();
      container.Register<StaticPeice, IStaticPiece>();
      Assert.Throws<TypeNotRegisteredException>(() => container.Resolve<TestController>());
    }

    /// <summary>
    /// a test for missing data types not being set
    /// </summary>
    [Fact]
    public void TestMissingData()
    {
      Container container = new Container();
      container.Register<LegacyPart, ILegacyPart>();
      container.Register<DataAccess, IDataAccess>();
      container.Register<LogicLayer, ILogicLayer>();
      container.Register<TestController, ITestController>();
      container.Register<StaticPeice, IStaticPiece>(Lifetime.Singleton);
      Assert.Throws<TypeNotRegisteredException>(() => container.Resolve<TestController>());
    }

    /// <summary>
    /// test that the connection string got set correctly
    /// </summary>
    [Fact]
    public void TestDataComposition()
    {
      string connStr = "Some Connection String";
      Container container = new Container();
      container.Register<LegacyPart, ILegacyPart>();
      container.Register<DataAccess, IDataAccess>();
      container.Register<LogicLayer, ILogicLayer>();
      container.Register<TestController, ITestController>();
      container.Register<StaticPeice, IStaticPiece>(Lifetime.Singleton);
      container.RegisterValue("connection", connStr);
      TestController controller = container.Resolve<TestController>();
      Assert.True(controller.GetConnection() == connStr);
    }
  }
}

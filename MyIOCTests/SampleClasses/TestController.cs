// <copyright file="TestController.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  /// <summary>
  /// the test controller
  /// </summary>
  public class TestController : ITestController
  {
    /// <summary>
    /// the static piece
    /// </summary>
    private IStaticPiece staticPiece;

    /// <summary>
    /// the logic layer
    /// </summary>
    private ILogicLayer logicLayer;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestController"/> class.
    /// </summary>
    /// <param name="logic">the logic layer</param>
    /// <param name="staticPiece">a static piece</param>
    public TestController(ILogicLayer logic, IStaticPiece staticPiece)
    {
      this.staticPiece = staticPiece;
      this.logicLayer = logic;
    }

    /// <summary>
    /// set the static data to something else
    /// </summary>
    /// <param name="data">the new static data</param>
    public void SetStaticData(string data)
    {
      this.staticPiece.StaticCheck = data;
    }

    /// <summary>
    /// return the static data
    /// </summary>
    /// <returns>the static data</returns>
    public string GetStaticData()
    {
      return this.staticPiece.StaticCheck;
    }

    /// <summary>
    /// get the connection from the database layer
    /// (wouldn't need this ever but it's a nice test)
    /// </summary>
    /// <returns>the connection</returns>
    public string GetConnection()
    {
      return this.logicLayer.GetConnection();
    }
  }
}

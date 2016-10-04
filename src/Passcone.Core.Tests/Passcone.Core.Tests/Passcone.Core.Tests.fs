module Passcone.Core.Tests
open NUnit.Framework
open Passcone.Core

[<Test>]
let ``Can we create a test case?`` () =
    // Arrange
    let o = Core()
    // Act
    let x = o.X
    // Assert
    Assert.IsTrue("F#" = x)
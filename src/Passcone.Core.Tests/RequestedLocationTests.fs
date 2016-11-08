module RequestedLocationTests
open NUnit.Framework
open BehaviorDSL
open Domain
open States
open Commands
open Events

[<Test>]
let ``Can request locations`` () =
  let location = { Latitude = 0M; Longitude = 0M }
  Given (FreedSpace None)
  |> When (RequestLocation location)
  |> ThenStateShouldBe (SearchingNearLocation location)
  |> WithEvents [LocationRequested location]


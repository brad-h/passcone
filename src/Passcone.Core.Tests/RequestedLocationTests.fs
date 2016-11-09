module RequestedLocationTests
open System
open NUnit.Framework
open BehaviorDSL
open Domain
open States
open Commands
open Events
open Errors

let location = { Latitude = 0M; Longitude = 0M }
[<Test>]
let ``Can request location when freed space`` () =
  Given (FreedSpace None)
  |> When (RequestLocation location)
  |> ThenStateShouldBe (SearchingNearLocation location)
  |> WithEvents [LocationRequested location]

[<Test>]
let ``Can request location when selected location`` () =
  Given (SearchingNearLocation { Latitude = 1M; Longitude = 1M })
  |> When (RequestLocation location)
  |> ThenStateShouldBe (SearchingNearLocation location)
  |> WithEvents [LocationRequested location]

[<Test>]
let ``Cannot request location when selected lot`` () =
  Given (SelectedLot { Name = ""; Location = location })
  |> When (RequestLocation location)
  |> ShouldFailWith CannotSearchWhenLotSelected

[<Test>]
let ``Cannot request location when selected space`` () =
  Given (SelectedSpace { Lot = { Name = ""; Location = location }; Unit = Guid.Empty })
  |> When (RequestLocation location)
  |> ShouldFailWith CannotSearchWhenSpaceSelected
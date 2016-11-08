module BehaviorDSL

open FsUnit
open NUnit.Framework
open Chessie.ErrorHandling
open Errors
open CommandHandler
open Commands
open States
open Events

let Given (state : State) = state

let When (command : Command) (state : State) = command, state

let ThenStateShouldBe (expectedState : State) (command, state) =
  match evolve state command with
  | Ok ((actualState, events), _) ->
    actualState |> should equal expectedState
    events |> Some
  | Bad errs ->
    sprintf "Expected: %A, but Actual: %A" expectedState errs.Head
    |> Assert.Fail
    None

let WithEvents (expectedEvents : Event list) (actualEvents : Event list option) =
  match actualEvents with
  | Some actualEvents ->
    actualEvents |> should equal expectedEvents
  | None ->
    None |> should equal expectedEvents

let ShouldFailWith (expectedError : Error) (command, state) =
  match evolve state command with
  | Bad errs -> errs.Head |> should equal expectedError
  | Ok (r, _) ->
    sprintf "Expected: %A, but Actual: %A" expectedError r
    |> Assert.Fail
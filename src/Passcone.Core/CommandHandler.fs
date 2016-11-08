module CommandHandler
open Chessie.ErrorHandling
open Domain
open Commands
open States
open Events
open Errors

let handleRequestLocation location = function
| FreedSpace _ ->
  [LocationRequested location]
  |> ok
| _ -> NotImplemented |> fail

let execute (state:State) command =
  match command with
  | RequestLocation location -> handleRequestLocation location state 
  | _ -> NotImplemented |> fail

let evolve state command =
  match execute state command with
  | Ok (events, _) ->
    let newState = List.fold apply state events
    (newState, events) |> ok
  | Bad err -> Bad err

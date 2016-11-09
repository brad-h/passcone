module States
open Domain
open Events

type State =
| FreedSpace of Space option
| SearchingNearLocation of Location
| SelectedLot of Lot
| SelectedSpace of Space

let apply state event =
  match state, event with
  | FreedSpace _, LocationRequested location -> SearchingNearLocation location
  | SearchingNearLocation _, LocationRequested location -> SearchingNearLocation location
  | _, _ -> state 
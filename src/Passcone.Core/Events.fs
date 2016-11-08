module Events
open Domain

type Event =
| LocationRequested of Location
| LotSelected of Lot
| SpaceSelected of Space
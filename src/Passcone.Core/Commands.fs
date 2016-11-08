module Commands
open Domain

type Command =
| RequestLocation of Location
| SelectLot of Lot
| SelectSpace of Space
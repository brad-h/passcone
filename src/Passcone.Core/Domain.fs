module Domain

open System

type Location = {
  Latitude : decimal
  Longitude : decimal
}

type Lot = {
  Location : Location
  Name : string
}

type Rate = {
  Amount : decimal
  Time : TimeSpan
}

type Space = {
  Lot : Lot
  Unit : Guid
}
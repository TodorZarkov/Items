# Items Web App

## App for your Items - you can store, find and get rid of your possessions 
#### There are  :
    - Items
    - Places and Locations where you store items
    - Easy way to search and locate items
    - Market to sell your unused or buy new items
    - There's a way to transfer the data from the new bought item 
    and use it to create your own
    - There's daily rotation  of number of items in randoom, so you can 
    summon few forgoten items

### Here's the structure of the app:
### **entities**
- users
    - default user
    - Guid id
    - items
    - own categories
    - locations
    - contracts

- categories
    - name
    - creator
    - items
- items
    - itemVisibility
    - access
    - name
    - added on
    - modified on
    - **category**
    - description
    - quantity
    - unit
    - acquired price
    - current price
    - currency
    - acquired date
    - acquire document(pdf)
    - **location**
    - **pictures**
    - main picture
    - owner
    - **offers**
    - **place**

- itemsCategories


- locations
    - ownerId (requ.)
    - name (requ.)
    - description
    - geolocation(-82.25330474983343, 179.91566825082487)
    - country (requ.)
    - town (requ.)
    - address
    - isPublic(false - not sell location, requ.)
    - **place**

- offers
    - buyer
    - item
    - value
    - currency
    - quantity
    - buyerLocation
    - barter item (not present)
    - date

- pictures
    - uri
    - isMain
    - item
    - isPrivate

- documents
    - uri
    - item
- places
    - name
    - location
    - description
- currencies
    - id
    - iso
    - name
    - symbol


- unit
    - name
    - symbol
- itemVisibility
    - item
- accounts
    - balance
    - currency
- contract
    - item
    - buyer
    - seller
    - price
    - currency
    - send due
    - deliver due
    - contract date
    - sellerOk
    - buyerOk
    - fulfilled
    - sellerComment
    - buyerComment
    - buyerConfirmed

- userContract

### entity relations 
- user 
    - has many items
    - has many locations
    - has many categories
    - has many accounts
    - has many contracts
- item
    - has one price (acquired price)
    - has one user (owner)
    - has one document (AcquireDocument)
    - has one location
    - has one place
    - has one unit (to measure quantity)
    - has one currency
    - has one itemVisibility
    - has many categories
    - has many offers
    - has many pictures
    
- category
    - has one user (creator)
    - has many items
- document
    - has many items
- location
    - has one user
    - has many places
- offer
    - has one user (buyer)
    - has one item
    - has one currency
    - has one location
    - has one item (for barter)
- picture
    - has one item
- place
    - has one location
- itemVisibility
    - has one item
- account
    - has one user
    - has one currency
- contract
    - has many users (2)
    - has one currency
    - has one item

    <img src="\ReadmeAssets\dbDiagram-20Aug2023-last.png" width="1800">

***

### managed by Admin
- categories - add, modify
- currencies - add, modify
- units - add, modify


### when Guest
- can see all public items with all their properties(if visible):
- cannot buy or bid on any item - redirect to login/register
- can see all categories
- search
#### views
- home(latest as landing)
- all
- categories(drop)
- search(on the bar)
## when User

#### views
- home (daily rotation)
- all not owner - bid/buy, details; if owner - details, put on market, remove from sell/auction, edit
- categories(is filter)
- my items - order/group by, add, quick add, ; edit, details, change place, change location
    - when deleting there are 5 conditions(dependencies) to observe:
        - ItemsCategories
        - Contracts !!! (here comes the conditional copy)
        - ItemVisibilities
        - Offers !!! (if the item is on the market)
        - Pictures
        - EndSellDateTime (if the item is on the market)
    - soft deleting is performed
    - cannot delete item on the  market - first remove from the market message
    - cannot edit item on auction - edit auction or remove from market message
- my categories
- my bids
    - bid - update, itemDetails, refresh
- my sells - all my items on sell or auction
- deals 
    - sell
        - hit buy
        - standard checks
        - fulfills form
        - standard checks
        - quantity check
        - quantity decrease
        - creates ItemInDelivery copy of the item for the contract
        - the contract is discussed over that copy
        - when the contract is fulfilled, the copy of the item stays 
for further references and the buyer may get the data to
create his own item
        - the relation to the original item persist until the contract is
fulfilled. So the relation is "one to zero or one" not "one to one".

- put on the market
    - above zero quantity is required
    - start end sell dates are required
    - when end sell date is not null and after now the sell is on
- locations
- places
- search

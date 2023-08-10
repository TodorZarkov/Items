## **Site with pics for items**

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
### managed by Admin
- categories - add, modify
- currencies - add, modify
- unit - add, modify


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
- my categories
- my bids
    - bid - update, itemDetails, refresh
- my sells
- deals
- locations
- places
- search

## **Site with pics for items**

### **entities**
- users
    - default user
    - items
    - own categories
    - locations

- categories
    - name
    - creator
    - items
- items
    - **location**
    - **place**
    - **category**
    - name
    - quantity
    - unit
    - description
    - **main picture address**
    - **pictures**
    - acquired date
    - acquired price
    - acquire document(pdf)
    - **offeredPrices**
    - **sellLocation**

- itemsCategories


- locations
    - ownerId (requ.)
    - name (requ.)
    - description
    - geolocation(-82.25330474983343, 179.91566825082487)
    - country (requ.)
    - town (requ.)
    - address
    - isPrivate(not sell location, requ.)
    - **place**

- offers
    - buyer
    - item
    - offeredPrice
    - buyerLocation
    - barter item

- pictures
    - uri
    - isMain
    - item

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

### entity relations 

## **Site with pics for items**

### **entities**
- users
    - default user
    - Guid id
    - items
    - own categories
    - locations

- categories
    - name
    - creator
    - items
- items
    - name
    - quantity
    - unit
    - description
    - acquired price
    - acquired date
    - acquire document(pdf)
    - **category**
    - **place**
    - **location**
    - **sellLocation**
    - **pictures**
    - **offers**

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
    - date

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

- price
    - value
    - currency

### entity relations 

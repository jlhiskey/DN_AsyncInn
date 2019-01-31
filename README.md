
# Lab 13-15: Async Inn Managment System 

- This Application is a hypothetical hotel asset management system using Entity Framework in an MVC application.
- This application uses dependency injection to create Repository middleware to serve as a connection between the application's Models and controllers. This is done by creating interfaces that are enabled  when interacting with the Room, Hotel, and Amenities Services. This creates a separation between the database being used to serve the site which means that a different database could be used to serve the site with minimal need to change the code base.
- Added searchbar functionality to Hotel, Room and Amenities.
   
## Resources
- MVC Setup https://github.com/codefellows/seattle-dotnet-401d6/blob/master/Class13/MVCSetup.md

## Example Usage
### On Page Load

![Home Index](assets/home.PNG)    

### All Hotels

#### Index

![All Hotels Index](assets/allHotels.PNG)

#### Create New

![All Hotels Create](assets/allHotelsCreate.PNG)

- After Create Button is selected.

![All Hotels Submit](assets/allHotelsCreateSubmit.PNG)

#### Edit

![All Hotels Edit](assets/allHotelsEdit.PNG)

#### Delete

![All Hotels Delete](assets/allHotelsDelete.PNG)

### Schema Used
![Hotel Schema](/assets/hotelSchema.png)    
- Used Code Fellows design.

### Tables:

#### Primary Tables
##### Hotel
- **Hotel** table is a collection of all Hotels. A **Hotel** can have multiple **Room**'s which are joined through the **HotelRoom** table.

##### Room
- **Room** table is a collection of all Room types. A **Room** can have multiple **Amenities**'s which are joined through the **RoomAmenities** table.

##### Amenities
- **Amenities** table is a collection of all Amenities types. **Amenities** can be in multiple **Room**'s which are joined through the **RoomAmenities** table.

#### Join Tables

##### HotelRoom
- **HotelRoom** table is a collection of all **Room**'s in a single **Hotel**. A **HotelRoom** table is an entity join table of **Room** and **Hotel** using **HotelID** and **RoomNumber** as a Composite Key. This table also provides a payload of **Price** and **PetFriendly**.

##### RoomAmenities
- **RoomAmenities** table is a collection of all **Amenities** in a single **Room**. A **RoomAmenities** table is an entity join table of **Room** and **Amenities** using **RoomID** and **AmenitiesID** as a Composite Key.




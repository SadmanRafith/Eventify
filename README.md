# Eventify (Event Management System)
Introducing Eventify, the ultimate solution for seamless event planning. Exhibit allows you to easily search for and book a wide range of events, from concerts to conferences and everything in between. With a user-friendly interface and real-time updates, you can browse upcoming events, check availability, and make reservations all in one place. Whether you're planning a night out with friends or a corporate event, also you can create events such as conference, concerts. Eventify app has you covered.

# How to use
First, make sure SQL Server Management Studio (SSMS) and Microsoft Visual Studio are installed. The database must be extracted using SSMS from the "Database Backup" folder. After that, you must change the Desktop name in the cs files to reflect the name of your desktop or laptop. 

For example: 
<code>con = new SqlConnection("Data Source=DESKTOP-TGP1F01;Initial Catalog=ExhibitDB;Integrated Security=True");</code>

replace <code>"DESKTOP-TGP1F01"</code> with the name of your desktop in specific files

## Softwares used: <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white"> <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white"> <img src="https://img.shields.io/badge/Adobe%20Photoshop-31A8FF?style=for-the-badge&logo=Adobe%20Photoshop&logoColor=black">

## Eventify (an event management system)
- User
   - Customer
   - Organiser
- Admin

  ## User Story of User

  ### Customer:
  After creating a new account (Sign Up) all Customer (Users and Organizers) are considered Regular users. With only the ability to register events.
A user can,
- Log in to their account.
- Update personal information and password after login.
- Reset password by email verification.
- Browse events that are created by organizers.
- Register multiple events.
- Choose the facilities offered by the organizers at their events.
- Edit registered events one day before the event date.
- Unregister events one day prior to the event.
- Recharge using purchased token provided by admins.
- View history of events registered.

  ### Organizer:
A user can send a request to admin to be an organizer. If admin accepts the request 
then the user becomes an organizer.
An organizer can,
- Do all the tasks that a user can do.
-	Organize events for other users to register.
-	Set facilities to their events.
-	Update the details of the events, one day before the event date.
-	Delete any events.
-	See the history of all events created by the organizer.
-	Can see the users who have registered to their events.
-	Can lock and unlock an event while creation or after creation of the event. Controlling the
editability of registered users to update their registration.

## User Story of Admin:
An admin is separate from the user. Admins can be added by only other admins. Admins have abilities that a normal User/ Customer does not have.
An admin can,
-	Add another admin.
-	Log in to their account by special username.
-	See all the events ever created by the organizers.
-	Monitor the details of all the users signed into the application.
-	See the events registered by each user.
-	See users who have registered to an event.
-	Block users to prevent them from registering any event.
-	Seize an event to prevent any further registration.
-	Generate recharge cards for the users to add balance to their account.

## Form Images
### Form 1: Account Creation
  ![image](https://github.com/user-attachments/assets/f7362f39-27aa-42e2-881c-6ded53579f28)

### Form 2: User Login
  ![image](https://github.com/user-attachments/assets/8d087e11-0513-4a6d-9379-2b23662f2ebd)

  ### Form 3: Forgot Password
  ![image](https://github.com/user-attachments/assets/9f8f0dc9-884b-4de6-a6d9-a20fdaf9225f)

  ### Form 4: Email Verification
  ![image](https://github.com/user-attachments/assets/fc52109e-877f-4e7d-a47c-7641ea50185b)

  ### Form 5: Home Page
  ![image](https://github.com/user-attachments/assets/c717b33b-7f38-4612-8f05-d719acf854d6)

  ### Form 6: Browse Events
  ![image](https://github.com/user-attachments/assets/d4a37667-2137-475f-8f3e-423bb93cb1f0)

  ### Form 7: Event Registration
  ![image](https://github.com/user-attachments/assets/a5b70d62-f3d0-483d-830b-be12ba7dccd9)

 ### Form 8: Payment
 ![image](https://github.com/user-attachments/assets/d874a1bd-078f-40ee-b84b-b4eb0936bad9)

 ### Form 9: Registered Events
 ![image](https://github.com/user-attachments/assets/072205e2-a0ef-4e3a-aa76-1d4fe7773577)

 ### Form 10: Update Registration details
 ![image](https://github.com/user-attachments/assets/3e42867f-995d-49df-9c03-5f0cb2752781)

 ### Form 11: Event Creation
 ![image](https://github.com/user-attachments/assets/bf1f6e54-2fde-4dfa-b2c2-d6c0ecb071f9)

 ### Form 12: Update Created Event
 ![image](https://github.com/user-attachments/assets/4dc8acf9-8b12-48e5-86f7-38d6d264513c)

 ### Form 13: Event History
 ![image](https://github.com/user-attachments/assets/ab74a8ca-9e40-4247-b7e9-be656c6f9034)

 ### Form 14: Settings Page
 ![image](https://github.com/user-attachments/assets/847a2ff7-aeb0-4d55-8a73-8fc49b2f84b8)

 ### Form 15: Change Account Information
 ![image](https://github.com/user-attachments/assets/e098b32c-815e-4458-a8d8-dcbc144353b7)

 ### Form 16: Change Password
 ![image](https://github.com/user-attachments/assets/aa485af0-64c3-4126-b74e-12f3173e025f)

 ### Form 17: Recharge
 ![image](https://github.com/user-attachments/assets/9ab887c3-9b09-4563-9358-721238c9ae7d)

### Form 18: Admin Panel (User Details)
![image](https://github.com/user-attachments/assets/faf10a4c-45d5-469e-a2f8-f7565c0cbeec)

### Form 19: Admin Panel (Registered event of user)
![image](https://github.com/user-attachments/assets/c0c575b4-bdd8-47d1-b525-424761313949)

### Form 20: Admin Panel (Event List)
![image](https://github.com/user-attachments/assets/b9ded9da-06ef-49cc-a60b-374686add9fd)

### Form 21: Admin Panel (Event Details)
![image](https://github.com/user-attachments/assets/805a0b33-998d-4087-b757-6987a6b7c87b)

### Form 22: Admin Panel (Registered Users)
![image](https://github.com/user-attachments/assets/8fdb6f62-ba11-4b2b-864b-84277d111862)

### Form 23: Admin Panel (Generate cards)
![image](https://github.com/user-attachments/assets/f360a26d-291b-4952-8200-3330e3162e40)

### Form 24: Admin Panel (Add Admins)
![image](https://github.com/user-attachments/assets/e15c9673-ef25-4489-bae1-7dfb6b483b08)

























  
                                 



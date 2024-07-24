# Hospital Room & Bed Reservation System
## Overview
The Hospital Room & Bed Reservation System is a desktop application designed to manage room and bed reservations for patients in a hospital. The system facilitates efficient resource allocation and patient management by providing different user roles with specific functionalities.

## User Roles
### Admins: Have comprehensive control over the system. They can manage rooms, user accounts, patient records, and reservations.
### Registrars: Responsible for managing reservations. They can view room availability and assign patients to rooms.
### Doctors: Can view patients assigned to them, along with detailed reservation and room information.

## Technologies Used
WPF (Windows Presentation Foundation): For building the graphical user interface.
.NET Framework: Provides the foundation for the application.
SQL Server: Serves as the relational database management system.
Entity Framework Core: Used as the Object-Relational Mapping (ORM) framework.
MVVM (Model-View-ViewModel): A design pattern that facilitates a clean separation of concerns, promoting maintainability and testability.
Entity Relationship Diagram

## The system's data model includes the following entities:

User: Represents all users, including admins, registrars, and doctors. Each user has an ID, username, password, first name, last name, and a role.
Doctor: A specialized user type with an additional specialization attribute, linked to patient reservations.
Patient: Contains personal details such as ID, first name, last name, gender, and date of birth.
Room: Defines the room details like ID, type, floor, capacity, and number.
Bed: Associated with rooms and reservations, includes details like bed ID, label, and occupancy status.
Reservation: Tracks patient stays, linking them to beds and doctors, and includes entry and exit dates.

## Key Functionalities
### Room Management: Admins can create and manage room details, including room type, capacity, and floor information.
### Patient Registration: Registrars can add new patients and assign them to available rooms and beds.
### Reservation Tracking: The system maintains a log of reservations, detailing the duration of the stay, the responsible doctor, and the assigned bed.

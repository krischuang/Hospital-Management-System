# Hospital Management System

A C# console application for managing a hospital's patients, doctors, appointments, and staff. Built as a university coursework project.

## Features

- Role-based login (Admin, Doctor, Patient, Receptionist), each with its own menu
- Patient records: registration, lookup, doctor assignment
- Appointment booking and management
- Flat-file persistence (`Data/*.txt`) — no external database required

## Tech Stack

- C# / .NET
- Console UI (no external UI framework)

## Project Structure

```
HospitalManagementConsole/
├── Program.cs        # Entry point — shows login menu, dispatches to role menu
├── Menu/              # Per-role console menus (Admin, Doctor, Patient, Receptionist, Login)
├── Models/            # Domain entities (User, Patient, Doctor, Admin, Receptionist, Appointment)
├── Service/           # File I/O, email, and generic helpers
└── Data/              # Flat-file "database" (patients, doctors, appointments, admins)
```

## Running

Open `HospitalManagementConsole.sln` in Visual Studio (or `dotnet run` from the `HospitalManagementConsole/` directory) and follow the console login prompts.

## Status

Coursework project — not intended for production use. Data persistence is flat-file based rather than a real database.

## License

MIT — see [LICENSE](LICENSE).

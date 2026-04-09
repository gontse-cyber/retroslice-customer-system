# Retroslice Customer System

A console-based customer management and qualification system for RetroSlice, a retro pizza and arcade establishment. This application captures customer data, evaluates qualification criteria, and generates statistics for loyalty program eligibility.

**Course:** PRG 182 - Milestone 1 (Second Year Programming)  
**Project Type:** Group Assignment

---

## Overview

RetroSlice Customer System is designed to streamline customer data collection and automate the qualification process for the RetroSlice loyalty program. The system captures comprehensive customer information—including demographics, purchasing history, and engagement metrics—and applies business logic to determine program eligibility.

### Key Features

- **Customer Data Collection** - Systematic capture of customer information including age, loyalty duration, and engagement metrics
- **Qualification Engine** - Automated business logic evaluation based on multiple criteria
- **Statistics Dashboard** - Real-time reporting of customer performance data
- **Interactive Menu System** - User-friendly navigation through all system functions

---

## Project Structure

```
Retroslice Customer System/
├── Program.cs                 # Main application logic
├── App.config                 # .NET Framework configuration
├── Milestone1.csproj         # Project file
├── Milestone1.sln            # Solution file
└── Properties/
    └── AssemblyInfo.cs       # Assembly metadata
```

---

## Technology Stack

- **Language:** C# (.NET Framework)
- **.NET Version:** .NET Framework 4.7.2
- **Platform:** Windows Console Application
- **Data Structure:** In-memory collections (Dictionary, List)

---

## How It Works

### 1. Data Collection Module
The system collects customer information through interactive prompts:
- Personal information (name, age)
- Loyalty history (start date)
- Engagement metrics (pizza consumption, bowling scores, slushy preferences)
- Employment status (conditional based on age)

### 2. Business Logic & Qualification Engine
Customers are evaluated against multiple criteria:
- **Employment Status** - Customer or guardian must be employed
- **Loyalty Duration** - Minimum 2 years as a customer
- **Engagement Score** - Combined metrics of game scores and consumption
- **Annual Consumption** - Minimum 3 pizzas per year
- **Disqualifiers** - Specific slushy preferences or insufficient annual slushy consumption

### 3. Statistics & Reporting
The system maintains and displays:
- Qualified vs. not-qualified customer lists
- High score rankings
- Bowling score statistics

---

## Usage

### Running the Application

```bash
./Milestone1.exe
```

### Menu Options

```
1. Capture    - Add a new customer to the system
2. Check      - View qualified and non-qualified customers
3. Stats      - Display customer statistics and rankings
4. Exit       - Close the application
```

### Example Workflow

```
Welcome to RetroSlice
1. Capture
2. Check
3. Stats
4. Exit
Choose an option: 1

What's your name: John Smith
How old are you: 28
What is your high score rank: 2500
When did you start being a loyal customer (YYYY-MM-DD): 2022-03-15
How many pizzas have you eaten since you've started being a customer: 48
What is your bowling high score: 1800
Are you employed (Y/N): Y
What is your slush-puppy flavour preference: cherry
How many slushies have you drank since you've started being a customer: 60
```

---

## Backend Architecture & Data Processing

### My Contributions (Backend Focus)

As a backend developer on this project, my contributions focused on the data processing, business logic, and qualification engine:

#### **1. Data Collection & Validation System**
- Designed the `collectData()` method to systematically capture and structure customer information
- Implemented input validation loops to ensure data integrity (with conditional age-based employment status checks)
- Managed type conversion and normalization of diverse input types into a unified dictionary-based data structure
- Ensured consistent data formatting for downstream processing

#### **2. Qualification Engine & Business Logic**
- Developed the `CheckQualifications()` method implementing multi-criteria evaluation logic
- Engineered the business rules engine evaluating:
  - Employment status validation
  - Loyalty duration calculations (date parsing and year-based comparison)
  - Multi-factor engagement scoring (combining game scores, consumption metrics)
  - Annual consumption rate calculations (dividing total consumption by tenure)
  - Disqualification criteria application
- Implemented complex conditional logic to determine eligibility based on product requirements

#### **3. Data Structure & State Management**
- Designed and implemented the Dictionary-based data model for customer records
- Created parallel data structures (qualified/not-qualified lists, statistics dictionaries) for efficient querying
- Managed in-memory data aggregation and lookup optimization

#### **4. Application Logic Flow**
- Architected the main application loop and state management
- Implemented the menu-driven interface with robust option handling
- Ensured data persistence throughout the application session
- Coordinated data flow between collection, validation, and reporting modules

#### **5. Reporting & Statistics**
- Built the statistics generation logic for customer ranking and scoring reports
- Implemented data aggregation from multiple sources (individual records and computed scores)
- Designed output formatting for clear presentation of customer performance data

---

## Data Flow Diagram

```
┌─────────────────────────────────────────────────────────┐
│          User Input (Console Menu)                      │
└────────────────────┬────────────────────────────────────┘
                     │
        ┌────────────┼────────────┐
        │            │            │
        ▼            ▼            ▼
    ┌────────┐  ┌────────┐  ┌──────────┐
    │ Capture│  │ Check  │  │  Stats   │
    └───┬────┘  └───┬────┘  └─────┬────┘
        │           │             │
        ▼           │             │
   ┌──────────┐     │             │
   │ Collect  │     │             │
   │ Customer │     │             │
   │ Data     │     │             │
   └────┬─────┘     │             │
        │           │             │
        ▼           │             │
   ┌──────────┐     │             │
   │ Validate │     │             │
   │ & Store  │     │             │
   └────┬─────┘     │             │
        │           │             │
        ▼           │             │
   ┌──────────────────────────────────┐
   │  Data Repository (Dictionaries)  │
   │  - qualified customers           │
   │  - not-qualified customers       │
   │  - rankings                      │
   │  - bowling scores                │
   └──────────────────────────────────┘
        │           ▲             ▲
        └───────────┤─────────────┘
                    │
        ┌───────────┴────────────┐
        │                        │
        ▼                        ▼
   ┌──────────┐          ┌───────────┐
   │ Display  │          │ Generate  │
   │ Lists    │          │ Reports   │
   └──────────┘          └───────────┘
```

---


### Data Structures
- **Dictionary<string, string>** - Flexible key-value customer records
- **List<string>** - Efficient customer classification
- **Dictionary<string, int>** - Score lookups and rankings


---

## Technical Learnings

This project provided valuable experience in:
- **Backend Logic Design** - Implementing complex business rules and qualification engines
- **Data Structure Selection** - Choosing appropriate collection types for different access patterns
- **Type Safety** - Managing type conversions and data consistency in C#
- **State Management** - Maintaining application state across multiple operations
- **User Input Processing** - Handling and validating diverse user input
- **Conditional Logic** - Designing multi-factor decision trees and business rule evaluation

---

## Group Members

This was a combined group effort for PRG 182, Milestone 1. My contribution focused on backend data processing, validation systems, and the qualification engine logic.

---

## Installation & Setup

### Prerequisites
- .NET Framework 4.7.2 or later
- Visual Studio 2019+ (or any C# IDE)
- Windows OS

### Build Instructions

1. Clone the repository:
```bash
git clone https://github.com/yourusername/retroslice-customer-system.git
cd Retroslice-Customer-System
```

2. Open in Visual Studio:
```bash
start Milestone1.sln
```

3. Build the solution:
```
Ctrl + Shift + B
```

4. Run the application:
```
Ctrl + F5
```

---

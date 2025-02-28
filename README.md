# OS-Project-1

# Multi-Threading and Inter-Process Communication in C#

## Overview
This repository contains two projects demonstrating key concepts in concurrent programming and inter-process communication (IPC) using C#.

### Project A: Multi-Threading Implementation
This project demonstrates multi-threading concepts in C# through a banking example. It includes four phases:
1. Basic Thread Operations: Create and manage threads for concurrent transactions.
2. Resource Protection: Use mutex locks to protect shared resources.
3. Deadlock Creation: Demonstrate how deadlocks occur in multi-threaded programs.
4. Deadlock Resolution: Implement strategies to prevent and recover from deadlocks.

### Project B: Inter-Process Communication (IPC) Using Pipes
This project demonstrates IPC using named pipes in C#. It consists of two programs:
1. Producer: Generates data and writes it to a named pipe.
2. Consumer: Reads data from the named pipe and processes it.

---

## Step-by-Step Instructions

### Project A: Multi-Threading Implementation
1. Clone the Repository:
   

2. Navigate to Project A:


3. Build and Run:

4. Expected Output:
   - The program will demonstrate thread creation, resource protection, deadlock scenarios, and deadlock resolution.


### Project B: Inter-Process Communication (IPC) Using Pipes
1. Navigate to Project B:
   

2. Build the Programs:

  
3. Run the Programs:
  

4. Expected Output:
   - The Producer will send a message to the Consumer via a named pipe.
   - The Consumer will receive and display the message.

# Water Jug Challenge API

## Description

This project provides an API to solve the classic Water Jug Problem. It allows users to determine the sequence of steps needed to measure out a specific amount of water using two jugs of different capacities and returns. The sequence with fewer steps.

## Table of Contents

- [Project Structure](#project-structure)
- [Algorithm Explanation](#algorithm-explanation)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)



## Project Structure

- `Controllers/WaterJugController.cs`: contains the API endpoints for the Water Jug Challenge.
- `Helpers/WaterJugHelper.cs`: This is a static class to solved the water jug challenge.
- `Models/Step.cs`: defines the structure of each step in the solution.
- `Models/WaterBucket.cs`: defines the water bucket with its capacity and current amount.
- `Models/RequestModels/WaterJugRequest.cs`: defines the request model for the API.


## Algorithm Explanation

First the algorithm checks if the solution is possible with the given values (x_capacity, y_capacity, z_amount_wanted). If it is not possible returns "No solution". 
If it is possible then the fun part begins.

To get the solution with few steps, first I had to check how many possible solutions there are. Due to the nature of the problem, there are always two possible ways to get to the solution:
1. Start by filling the X bucket and pour it into the Y bucket.
2. Start by filling the Y bucket  and pour it into the X bucket.

With this in mind, I created a function that takes the bucket capacities and creates two WaterBuckets objects. Then in a while loop it starts filling, pouring and throwing the water until it reaches the solution and returns the steps taken to get to the solution. Then I called the function two times, 
1. one with Bucket X as the first bucket to fill 
2. and one with Bucket Y as the first bucket to fill.  

Then compare which one has less steps and return the steps of the fastest one.

- Note: Given more time, the algorithm could be improved to stop the remaining loop when one finishes. 


## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any other compatible IDE
- [Postman](https://www.postman.com/downloads/) (optional, for API testing)

## Installation

1. Clone the repository:
   ```bash
   git clone git@github.com:dekuvjs/chick-gold-backend-challenge.git
   ```
2. Navigate to the project directory:
   ```bash
   cd chicks-gold-backend-challenge
   ```
3. Restore the dependencies:
   ```bash
    dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```

## Usage

1. Run the application:
   ```bash
   dotnet run --project WaterJugChallenge.csproj
   ```
2. The API will be available at `https://localhost:7108` or `http://localhost:5173`.

3. The api is also available with Swagger UI at `http://localhost:5173/swagger` for easy testing and exploration of the endpoints.

## API Endpoints

- `POST /api/WaterJug/calculate`: Accepts a JSON payload with bucket capacities and wanted amount, returns the fastest sequence of steps to achieve the target.

  **Request Body Example:**

  ```json
  {
    "x_capacity": 2,
    "y_capacity": 10,
    "z_amount_wanted": 4
  }
  ```

  **Response Example:**

  ```json
  {
    "solution": [
      { "step": 1, "bucketX": 2, "bucketY": 0, "action": "Fill bucket X" },
      {
        "step": 2,
        "bucketX": 0,
        "bucketY": 2,
        "action": "Transfer from bucket X to Y"
      },
      { "step": 3, "bucketX": 2, "bucketY": 2, "action": "Fill bucket X" },
      {
        "step": 4,
        "bucketX": 0,
        "bucketY": 4,
        "action": "Transfer from bucket X to Y",
        "status": "Solved"
      }
    ]
  }
  ```

## Testing

To run the unit tests, navigate to the `Tests` directory and execute the following command:

```bash
dotnet test
``` 




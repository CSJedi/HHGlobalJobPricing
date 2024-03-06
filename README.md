# HHGlobalJobPricing
**Project Title**

HH Global Job Pricing

**Description**

The HH Global Job Pricing project is a web service that calculates the total charge for a job based on the items in the job. It takes into account sales tax, margins, and any extra margins that may apply. The service exposes an API that accepts job details in JSON format and returns the total charge in JSON format.

**Installation**

To run the HH Global Job Pricing project, ensure you have the following components installed:

- Visual Studio 2022 
- .NET 8 SDK 
- NUnit test adapter (for running unit tests)

**Running the Project**

1. Clone the repository to your local machine.
2. Open the solution file (`HHGlobalJobPricing.sln`) in Visual Studio.
3. Build the solution to restore packages and build the project.
4. Run the project by pressing `F5` or clicking the start button in Visual Studio.

**API Usage**

The API provides the following endpoint:

- **POST** `/api/pricing/calculate`

**Request Body Examples**

```json
{
  "hasExtraMargin": false,
  "items": [
    { "name": "item", "cost": 100.00, "isTaxExempt": false }
  ]
}
```

```json
{
  "hasExtraMargin": true,
  "items": [
    { "name": "envelopes", "cost": 520.00, "isTaxExempt": false },
    { "name": "letterhead", "cost": 1983.37, "isTaxExempt": true }
  ]
}
```

**Response Body Examples**

```json
{
  "items": [
    { "name": "t-shirts", "cost": 314.62 }
  ],
  "total": 346.96
}
```

```json
{
  "items": [
    { "name": "envelopes", "cost": 556.40 },
    { "name": "letterhead", "cost": 1983.37 }
  ],
  "total": 2940.30
}

```

**Swagger UI**

You can also use Swagger UI to explore and test the API. Start the project and navigate to `https://localhost:<port>/swagger` in your browser.

**Running Unit Tests**

To run unit tests, open the Test Explorer in Visual Studio and click "Run All" to execute all unit tests.

**Contributing**

Contributions to the HH Global Job Pricing project are welcome. If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

**License**

This project is licensed under the MIT License. See the [LICENSE](link-to-license-file) file for details.
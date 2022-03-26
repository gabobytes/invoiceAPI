# API REST .NET

Run script invoice-script-database.sql on your SQL Server Database Management  

 

## Development server

Run at `IIS Express` . Navigate to `http://localhost:1451/Api/`.  



## Endpoints

http://localhost:1451/Api/Product  

http://localhost:1451/Api/Client  

http://localhost:1451/Api/Invoice  

http://localhost:1451/Api/InvoiceProduct  



## Json Data Sample

Trying http://localhost:1451/Api/Product we get:   
  


{  

	"data": [  

		{  

			"id": 1,  

			"productname": "Pleo San Brucel XXX",  

			"value": 4580.0  


		},  


		{  

			"id": 2,  

			"productname": "Migraine Version UP",  

			"value": 3500.0  

		}  

	]  

}  


## Clean Architecture

Three projects was created and based on clean architecture:  


-Invoicing.Api  

-Invoicing.Core  

-Invoicing.Infrastructure  

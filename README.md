# CreditManaging
Back end asp.net web api

##github workflow branch - creditmanage-patch-1
##Back end asp.net web api While testing with postman disable ssl

1.GET/ customer

POST/ RegisterCustomer request body { "Id": 2, "Name": "test1", "CreditLimit": "high", "PaymentTerms": "chq" }

GET /CustomerAccounts/id

GET /SaleInvoices/Id

POST /Sale request body { "Id": 2, "product": "test", "amount": "299", "transactionDate": "2022-03-02T00:00:00", "price": "199", "unit": "1", "paymentTerms": "30", "paymentMode": "chq", "dueDate": "2022-04-11T00:00:00", "customerId": 1 }

POST /MakePayment request body { "Id": 10, "InvoiceId": 1, "Amount": "100", "PayDate": "2021-11-11T00:00:00", "DueDate": "2021-11-11T00:00:00", "SaleInvoice": [ { "Id": 1, "ActualBalance": "1000", "AvailableBalance": "99", "CreditLimit": "2000" } ] }

GET / Payments/{customerid}

POST /Reverse Sale { "Id": 2, "product": "test", "amount": "299", "transactionDate": "2022-03-02T00:00:00", "price": "199", "unit": "1", "paymentTerms": "30", "paymentMode": "chq", "dueDate": "2022-04-11T00:00:00", "customerId": 1, "rejectStatus" : 1, "paidStatus" : 0 }

GET /UnPaidInvoices/id

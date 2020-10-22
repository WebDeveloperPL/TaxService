# TaxService

## Application description
This app is a WebAPI project where you can calculate VAT for collection of items. This project use predefined database with VAT rates, current setup has only few groups, for testing purpose

## Vat rate groups
building_service	8%
books	5%
newspapers 5%

## Configuration of vat rate groups

If service or good is not in predefined category, it will use default value of VAT which is 23%. 

Default flag can be chaned on database level. However, if request contains a key which doesn't exists in database, and there is no default vat rate defined, API will return BadRequest response. 

Application is build on .Net Core 3.1. There is no user interface, only WebAPI. Use swagger for testing. 

## First run
Application should create database automatically after application start. Before running application, setup correct connection string in configuration file.

  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\sqlexpress;Database=taxdb;Trusted_Connection=True;"
  },
  
## implementation 
- database context is registered as transient, so it's independent on every database action
- added implementation which automatically register all implementations in container (RegisterScopedAttribute)
- interfaces are in the same file as implementation by design (it can be separated when having more than one implementation for particular interface)
- code structure is multilayered (providers, factories, repositories)
- created some unit tests for checking if outcome model is correct, checked some edge cases


Please, use following model for testing POST action:

[
{  "key" : "building_service", "amount" : 1, "singleItemPrice" : 100.89}, 
{  "key" : "books", "amount" : 10, "singleItemPrice" : 50},
{  "key" : "newspappers", "amount" : 1, "singleItemPrice" : 100},
{  "key" : "something_else", "amount" : 1, "singleItemPrice" : 12345}  
]

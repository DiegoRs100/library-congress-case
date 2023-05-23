# Library Congress Project - A DDD Workshop

Domain Driven-Design is an approach to software development with a series of ideas and principles that may simplify the development and delivery of more value in the product.

This training has the goal to explain DDD with a business case, showing the creational process, and thinking about the product,  architecture, and code. From your conception until the deliver.

## Who is this training for?

People who have been working with software development for some time, and who understand the basic concepts of an application/system/software. It is important to know about OOP (Object-Oriented Programming), too.

__Level:__ Intermediate

## Content to be Explored:

#### Architecture/Structure

* API (Application Programming Interface)
* Monolithic structure
* Onion Architecture


#### Principles

* Domain Driven-Design
	* Strategic
		* Ubiquitous Language
		* Context Map
		* Bounded Context
	* Tactical

#### Patterns

* CQRS (Command and Query Responsibility Segregation)
* Repository Pattern
* Notification Pattern

#### Technologies

* .NET 8
* MediatR
* Dapper
* Entity Framework
* Automapper
* FluentValidation

---

## Modules

### Shelf Module
![SHELF UML](.\.assets\images\uml-shelf-module.png)

Create a migration:
`Add-Migration ShelfStructure -Project Library.Shelf.Infra -OutputDir Databases\Migrations`

Execute a migration:
`Update-Database -Project Library.Shelf.Infra`
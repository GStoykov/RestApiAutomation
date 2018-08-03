Feature: Get books
	#In order to GET list of books in a library
	#As a API consumer
	#I want to be able request such information through endpoints

#Background:
	#Given Following books are in the library

	#| Id | Author      | Title       | Description |
	#| 1  | Aaa Aaa Aaa | Aaa Aaa Aaa | Aaa Aaa Aaa |
	#| 2  | Bbb Bbb Bbb | Bbb Bbb Bbb | Bbb Bbb Bbb |


Scenario: Get all books
	Given Following books in library:
	| Id | Title      | Description      | Author      |
	| 1  | TestTitle1 | TestDescription1 | TestAuthor1 |
	| 2  | TestTitle2 | TestDescription2 | TestAuthor2 |
	When 'GET' request to '/books' endpoint
	And Execute request
	Then Response is collection of:
	| Id | Title      | Description      | Author      |
	| 1  | TestTitle1 | TestDescription1 | TestAuthor1 |
	| 2  | TestTitle2 | TestDescription2 | TestAuthor2 |


Scenario: Get all books when there are none
	Given 'GET' request to '/books' endpoint
	And Execute request
	And Response is collection of:
	||

	
Scenario: Get book by id
	Given 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response is:
	| Id | Title     | Description     | Author     |
	| 6  | TestTitle | TestDescription | TestAuthor |


Scenario: Get unexisting book by id
	Given 'GET' request to '/books/9' endpoint
	And Execute request
	Then Response is:
	| Message                   |
	| Book with id 9 not found! |

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
	Given 'GET' request to '/books' endpoint
	#And There are books in the libraby
	And Execute request
	And Response is:
	| Id | Title     | Description     | Author     |
	| 6  | TestTitle | TestDescription | TestAuthor |
	#| 3  | TestTitle | TestDescription | TestAuthor |


Scenario: Get all books when there are none
	Given 'GET' request to '/books' endpoint
	And Execute request
	And Response is:
	||

	
Scenario: Get book by id
	Given 'GET' request to '/books/6' endpoint
	And Execute request
	And Response is:
	| Id | Title     | Description     | Author     |
	| 6  | TestTitle | TestDescription | TestAuthor |


Scenario: Get unexisting book by id
	Given 'GET' request to '/books/9' endpoint
	And Execute request
	And Response is:
	| Message                   |
	| Book with id 9 not found! |

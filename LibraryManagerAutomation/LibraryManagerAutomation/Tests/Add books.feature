Feature: Add books
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add book 
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
	| Id | Author      | Title       | Description |
	| 1  | TestTitle | TestDescription | TestAuthor |
	And Execute request
	Then 'GET' request to '/books/1' endpoint
	And Execute request
	And Response is:
	| Id | Title     | Description     | Author     |
	| 1  | TestTitle | TestDescription | TestAuthor |


# Adding the same book twice
Feature: Add books
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add book 
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title      | Description      | Author      |
		| 1  | TestTitle1 | TestDescription1 | TestAuthor1 |
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title      | Description      | Author      |
		| 1  | TestTitle1 | TestDescription1 | TestAuthor1 |

	Then 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title      | Description      | Author      |
		| 1  | TestTitle1 | TestDescription1 | TestAuthor1 |


# Adding the same book twice
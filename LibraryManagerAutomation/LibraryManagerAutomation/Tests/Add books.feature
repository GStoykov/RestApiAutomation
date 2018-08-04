Feature: Add books
	In order to add books in a library
	As a API consumer
	I want to be able to send book information through endpoint and be saved in the library

@bug1
Scenario: Users can add new book to the library
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Description       | Author       |
		| 1  | Test Title1 | Test Description1 | Test Author1 |
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description       | Author       |
		| 1  | Test Title1 | Test Description1 | Test Author1 |

	Then 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description       | Author       |
		| 1  | Test Title1 | Test Description1 | Test Author1 |


@bug1
Scenario: Users cannot add a book, when there is already another in the library with the same "id" 
	Given Following books in library:
        | Id | Title       | Description       | Author       |
		| 2  | Test Title1 | Test Description1 | Test Author1 |
	When 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Description       | Author       |
        | 2  | Aaa Bbb Ccc | Test Description2 | Test Author2 |
	And Execute request
	Then Response code is '400'
	And Response is:
		| Message                        |
		| Book with id 2 already exists! |

	Then 'GET' request to '/books/2' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description       | Author       |
		| 2  | Test Title1 | Test Description1 | Test Author1 |


#Query: 4. Should users be able to add a book with the Title, Description and Author where such book already exist in the library under different id?
#@bug1 @unknown
#Scenario: Users cannot add book identical with already existing in the library 
#	Given Following books in library:
#        | Id | Title       | Description       | Author       |
#		| 2  | Test Title1 | Test Description1 | Test Author1 |
#	When 'POST' request to '/books' endpoint
#	And Add request payload as JSON object:
#		| Id | Title       | Description       | Author       |
#		| 3  | Test Title1 | Test Description1 | Test Author1 |
#	And Execute request
#Unknown 
#	Then Response code is ''
#	And Response is:
#		
#
#	Then 'GET' request to '/books/3' endpoint
#	And Execute request
#	Then Response code is ''
#	And Response is:


@bug1 @assumedBug4
Scenario Outline: Users cannot add book with invalid parameters
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id   | Title   | Description   | Author   |
		| <id> | <title> | <description> | <author> |
	When Execute request
	Then Response code is '400'
	And Response is:
		| Message                                                       |
		| Book.Id should be a positive integer! Parameter name: book.Id |

	Then 'GET' request to '/books/2' endpoint
	And Execute request
	Then Response code is '404'
	And Response is collection of:
	||

Examples: 
| id  | title         | description         | author         |
| fsd | Test Title    | Test Description    | Test Author    |
| 1@  | Test Title    | Test Description    | Test Author    |
# add for integers here


@bug1
Scenario Outline: Users can use special symbols in book's "Title", "Description" and "Author"
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id   | Title   | Description   | Author   |
		| <id> | <title> | <description> | <author> |
	When Execute request
	Then Response code is '200'

	Then 'GET' request to '/books/<id>' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id   | Title   | Description   | Author   |
		| <id> | <title> | <description> | <author> |

Examples: 
| id  | title         | description         | author         |
| 1   | Test Title    | Test@#' Description | Test Author    |
| 1   | Test@#' Title | Test Description    | Test Author    |
| 1   | Test Title    | Test Description    | Test@#' Author |



#@bug1 @unknown
#Scenario: Users can add batch of new books to the library
#	Given 'POST' request to '/books' endpoint
#	And Add request payload as JSON collection:
#		| Id | Title       | Description       | Author       |
#		| 1  | Test Title1 | Test Description1 | Test Author1 |
#	And Execute request
#	Then Response code is '200'
#	And Response is:
#		| Id | Title       | Description       | Author       |
#		| 1  | Test Title1 | Test Description1 | Test Author1 |
#
#	Then 'GET' request to '/books/1' endpoint
#	And Execute request
#	Then Response code is '200'
#	And Response is:
#		| Id | Title       | Description       | Author       |
#		| 1  | Test Title1 | Test Description1 | Test Author1 |




# Adding book by not providing all details
# adding book by providing null
# Adding book by prodiving invalid pameters in invalid format
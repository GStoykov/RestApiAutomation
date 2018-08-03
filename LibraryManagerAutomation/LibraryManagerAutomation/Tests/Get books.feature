Feature: Get books
	In order to retrieve books in a library
	As a API consumer
	I want to be able request such information through endpoints


#| Id | Title       | Description       | Author       |
#| 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
#| 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |
#| 3  | Aaa Fff Ggg | Test Description2 | Test Author3 |


@bugAuthorNull
Scenario: Users can retrieve all books in the library
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
         | 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |
	When 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
         | 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |


#Query: 1.Should books filtering be case-sensitive?
@bugAuthorNull
Scenario Outline: Users can retrieve books by 'title' containing specific text
	Given Following books in library:
		 | Id | Title       | Description           | Author           |
		 | 1  | Aaa Bbb Ccc | Test Description1     | Test Author1     |
		 | 2  | KKK Ddd Eee | Aaa Test Description2 | Test Author2     |
		 | 3  | NNN Ddd Eee | Aaa Test Description2 | Aaa Test Author2 |
		 | 4  | Aaa Fff Ggg | Test Description2     | Test Author3     |
	When 'GET' request to '/books?<filter>=<filterValue>' endpoint
	And Execute request
	Then Response code is '200'
	Then Response is collection of:
		 | Id | Title       | Description       | Author       |
		 | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
		 | 4  | Aaa Fff Ggg | Test Description2 | Test Author3 |

Examples: 
| filter | filterValue |
| title  | Aaa         |
| Title  | Aaa         |
#assumed:
| title  | aaa         |


Scenario: Retrieving books by non-existing title
	Given Following books in library:
		 | Id | Title       | Description           | Author           |
		 | 1  | Aaa Bbb Ccc | Test Description1     | Test Author1     |
		 | 2  | KKK Ddd Eee | Aaa Test Description2 | Test Author2     |
		 | 3  | NNN Ddd Eee | Aaa Test Description2 | Aaa Test Author2 |
		 | 4  | Aaa Fff Ggg | Test Description2     | Test Author3     |
	When 'GET' request to '/books?title=Ppp' endpoint
	And Execute request
	Then Response is collection of:
		 ||


#Query: 2. Should books filtering be possible only by "title"
Scenario Outline: Users cannot filter books by properties different than "title"
	Given Following books in library:
         | Id | Title       | Description      | Author      |
         | 1  | Test Title1 | Aaa Description1 | Bbb Author1 |
         | 2  | Test Title2 | Bbb Description2 | Aaa Author2 |
         | 3  | Aaa Title3  | Bbb Description3 | Ccc Author3 |
	When 'GET' request to '/books?<filter>=<filterValue>' endpoint
	And Execute request
	Then Response is collection of:
		 ||

Examples: 
| filter      | filterValue |
| Description | Aaa         |
| Author      | Aaa         |



#Query: 3. What should be the response on attempt to retrieve empty libraby?
Scenario: Retrieving all books when there are none
	Given 'GET' request to '/books' endpoint
	And Execute request
	And Response is collection of:
	||


@assumedExpectedResult
Scenario: Get books by id
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	When 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response is:
		| Id | Title       | Description       | Author       |
		| 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	
#
#Scenario: Get unexisting book by id
#	Given 'GET' request to '/books/9' endpoint
#	And Execute request
#	Then Response is:
#	| Message                   |
#	| Book with id 9 not found! |
#
#
#Scenario Outline: Get book by filter
#	Given Following books in library:
#         | Id | Title       | Description      | Author      |
#         | 1  | Test Title1 | TestDescription1 | TestAuthor1 |
#         | 2  | Test Title2 | TestDescription2 | TestAuthor2 |
#	When 'GET' request to '/books?title=<filterText>' endpoint
#	And Execute request
#	Then Response is collection of:
#		 | Id | Title       | Description      | Author      |
#         | 1  | Test Title1 | TestDescription1 | TestAuthor1 |
#	Examples: 
#	| filterText |
#	| Title1     |
#	| Title3     |
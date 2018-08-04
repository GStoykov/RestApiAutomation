Feature: Get books
	In order to retrieve books in a library
	As a API consumer
	I want to be able request such information through endpoints


@bug1
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
@bug1
Scenario Outline: Users can retrieve books by "title" containing specific text
	Given Following books in library:
		 | Id | Title       | Description           | Author           |
		 | 1  | Aaa Bbb Ccc | Test Description1     | Test Author1     |
		 | 2  | KKK Ddd Eee | Aaa Test Description2 | Test Author2     |
		 | 3  | NNN Ddd Eee | Aaa Test Description2 | Aaa Test Author2 |
		 | 4  | Aaa Bbb Ggg | Test Description4     | Test Author4     |
	When 'GET' request to '/books?<filter>=<filterValue>' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		 | Id | Title       | Description       | Author       |
		 | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
		 | 4  | Aaa Fff Ggg | Test Description4 | Test Author4 |

Examples: 
| filter | filterValue |
| title  | Aaa         |
| title  | Aaa Bbb     |
| Title  | Aaa         |
#query
#| title  | aaa         |


#Query: 2. What response code should be returned when books were not found 200 or 404? What error message should be returned in this case?
@assumedBug2
Scenario: Retrieving books by non-existing title
	Given Following books in library:
		 | Id | Title       | Description           | Author           |
		 | 1  | Aaa Bbb Ccc | Test Description1     | Test Author1     |
		 | 2  | KKK Ddd Eee | Aaa Test Description2 | Test Author2     |
	When 'GET' request to '/books?title=Ppp' endpoint
	And Execute request
	Then Response code is '404'
	And Response is collection of:
		 ||


#Query: 3. Should books filtering be available only by "title"
@bug3
Scenario Outline: Users cannot filter books by properties other than "title"
	Given Following books in library:
         | Id | Title       | Description      | Author      |
         | 1  | Test Title1 | Aaa Description1 | Bbb Author1 |
         | 2  | Test Title2 | Bbb Description2 | Aaa Author2 |
         | 3  | Aaa Title3  | Bbb Description3 | Ccc Author3 |
	When 'GET' request to '/books?<filter>=<filterValue>' endpoint
	And Execute request
	Then Response code is '400'
	And Response is collection of:
		 ||

Examples: 
| filter      | filterValue |
| Description | Aaa         |
| Author      | Aaa         |


Scenario: Retrieving all books when there are none
	Given 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
	||


@bug1
Scenario: Users can retrieve book by its id
	Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 3  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	When 'GET' request to '/books/3' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description       | Author       |
		| 3  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	


Scenario: Message is returned when retrieving non-existing book by id 
Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	When 'GET' request to '/books/6' endpoint
	And Execute request
	Then Response code is '404'
	And Response is:
		| Message                   |
		| Book with id 6 not found! |


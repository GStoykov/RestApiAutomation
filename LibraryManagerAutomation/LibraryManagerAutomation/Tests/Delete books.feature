Feature: Delete books
	In order to remove books from a library
	As a API consumer
	I want to be able to send information to endpoint which books to be removed

@noResponse
Scenario: Users can delete a book by "Id"
	Given Following books in library:
        | Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
	
	Given 'DELETE' request to '/books/1' endpoint
	And Execute request
	Then Response code is '204'
	And Response messaage is not returned

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		||


Scenario: Users are informed on attempt to delete non-existing book by "Id"
	Given 'DELETE' request to '/books/1' endpoint
	And Execute request
	Then Response code is '404'
	And Response is:
		| Message                   |
		| Book with id 1 not found! |

@bug1
Scenario: Deleting books without specifying "Id"
	Given Following books in library:
        | Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
        | 2  | Test 2     | Test 2           | Test 2      |
	
	Given 'DELETE' request to '/books' endpoint
	And Execute request
	Then Response code is '405'
	And Response messaage is not returned
	And Response is:
		| Message                                                       |
		| The requested resource does not support http method 'DELETE'. |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		| Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
        | 2  | Test 2     | Test 2           | Test 2      |

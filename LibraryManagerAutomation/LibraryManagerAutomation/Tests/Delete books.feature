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

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		||


@noResponse
Scenario: User are informed on attempt to delete non-existing book by "Id"
	Given 'DELETE' request to '/books/1' endpoint
	And Execute request
	Then Response code is '404'


@noResponse @bug1
Scenario: Deleting books without specifying "Id"
	Given Following books in library:
        | Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
        | 2  | Test 2     | Test 2           | Test 2      |
	
	Given 'DELETE' request to '/books' endpoint
	And Execute request
	Then Response code is '405'

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		| Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
        | 2  | Test 2     | Test 2           | Test 2      |

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


@bug1 @bug7
Scenario Outline: Users can create a book with max characters for parameter(s)
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id   | Title   | Description      | Author   |
		| <id> | <title> | Test Description | <author> |
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id   | Title   | Description      | Author   |
		| <id> | <title> | Test Description | <author> |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		| Id   | Title   | Description      | Author   |
		| <id> | <title> | Test Description | <author> |

Examples: 
| id | title                                                                                                | author                         |
#title 100 chars
| 1  | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa | Test author                    |
#author 30 chars
| 1  | Test title                                                                                           | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa |


@bug1
Scenario: Users can add new book without passing parameter "Description"
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Author       |
		| 1  | Test Title1 | Test Author1 |
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description | Author       |
		| 1  | Test Title1 | $null       | Test Author1 |

	Then 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description | Author       |
		| 1  | Test Title1 | $null       | Test Author1 |


@bug1
Scenario: Users can add new book with empty "Description"
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Description | Author       |
		| 1  | Test Title1 | $null       | Test Author1 |
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description | Author       |
		| 1  | Test Title1 | $null       | Test Author1 |

	Then 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description | Author       |
		| 1  | Test Title1 | $null       | Test Author1 |


@bug1 @bug4
Scenario Outline: Users cannot create a book by exceeding parameter value constaints
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id   | Title   | Description      | Author   |
		| <id> | <title> | Test Description | <author> |
	And Execute request
	Then Response code is '400'
	And Response is:
		| Message   |
		| <message> |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		||

Examples: 
| id | title                                                                                                 | author                          | message                                                                  |
| 0  | Test title                                                                                            | Test author                     | Book.Id should be a positive integer! Parameter name: book.Id            |
#title 101 chars
| 1  | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaZ | Test author                     | Book.Title should not exceed 100 characters! Parameter name: Book.Title  |
#author 31 chars
| 1  | Test title                                                                                            | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaZ | Book.Author should not exceed 30 characters! Parameter name: Book.Author |


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


@bug4 @bug6
Scenario Outline: Users cannot add book without providing "Id", "Title" and "Author"
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| <property1>       | <property2>       | <property3>       | 
		| <property1_Value> | <property2_Value> | <property3_Value> |
	When Execute request
	Then Response code is '400'
	And Response is:
		| Message   |
		| <message> |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '404'
	And Response is collection of:
	||

Examples: 
| property1 | property2   | property3   | property1_Value | property2_Value  | property3_Value  | message                                                                |
| Title     | Description | Author      | Test title      | Test Description | Test Author      | Book.Id should be a positive integer! Parameter name: book.Id          |
| Id        | Description | Author      | {int}1          | Test Description | Test Author      | Book.Title is a required field. Parameter name: book.Title             |
| Id        | Title       | Description | {int}1          | Test title       | Test Description | Book.Author is a required field. Parameter name: book.Author           |


@bug4 @bug6 @query6
Scenario Outline: Users cannot add book with invalid parameter values
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id   | Title   | Description   | Author   |
		| <id> | <title> | <description> | <author> |
	When Execute request
	Then Response code is '400'
	And Response is:
		| Message   |
		| <message> |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '404'
	And Response is collection of:
	||

Examples: 
| id  | title      | description      | author      | message                                                       |
| one | Test Title | Test Description | Test Author | Book.Id should be a positive integer! Parameter name: book.Id |
| 1   | {int}123   | Test Description | Test Author | TBC                                                           |
| 1   | Test Title | {int}123         | Test Author | TBC                                                           |
| 1   | Test Title | Test Description | {int}123    | TBC                                                           |
| 1   | {int}123   | {int}456         | {int}789    | TBC                                                           |




@ignore @bug1 @unknown @query4
Scenario: Users cannot add book identical with already existing in the library 
	Given Following books in library:
        | Id | Title       | Description       | Author       |
		| 2  | Test Title1 | Test Description1 | Test Author1 |
	When 'POST' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Description       | Author       |
		| 3  | Test Title1 | Test Description1 | Test Author1 |
	And Execute request
##Unknown 
#	Then Response code is ''
#	And Response is:
#		
#
#	Then 'GET' request to '/books/3' endpoint
#	And Execute request
#	Then Response code is ''
#	And Response is:


@ignore @bug1 @unknown @query5
Scenario: Users can add batch of new books to the library
	Given 'POST' request to '/books' endpoint
	And Add request payload as JSON collection:
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


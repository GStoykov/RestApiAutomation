Feature: Update books
	In order to maintain books in a library
	As a API consumer
	I want to be able to update books' details through endpoint


@bug5
Scenario Outline: User can update book information by "Id"
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
         | 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |
	
	Given 'PUT' request to '/books/1' endpoint
	And Add request payload as JSON object:
		| Id | Title   | Description   | Author   |
		| 1  | <title> | <description> | <author> |
	And Execute request
	Then Response code is '200'
	And Response is:
         | Id | Title   | Description   | Author   |
         | 1  | <title> | <description> | <author> |

	Then 'GET' request to '/books/1' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title   | Description   | Author   |
		| 1  | <title> | <description> | <author> |

Examples:
| id | title             | description       | author            |
| 1  | Change change 1@' | Test Description1 | Test Author1      |
| 1  | Aaa Bbb Ccc       | Change change 1@' | Test Author1      |
| 1  | Aaa Bbb Ccc       | Test Description1 | Change change 1@' |
| 1  | Change change 1@' | Change change 1@' | Change change 1@' |


@bug1
Scenario Outline: Update of a given book does not update the details of other books
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
         | 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |
	
	Given 'PUT' request to '/books/1' endpoint
	And Add request payload as JSON object:
		| Id | Title   | Description   | Author   |
		| 1  | <title> | <description> | <author> |
	And Execute request
	Then Response code is '200'
	And Response is:
         | Id | Title   | Description   | Author   |
         | 1  | <title> | <description> | <author> |

	Then 'GET' request to '/books/2' endpoint
	And Execute request
	Then Response code is '200'
	And Response is:
		| Id | Title       | Description       | Author       |
		| 2  | Aaa Ddd Eee | Test Description2 | Test Author2 |

Examples:
| id | title             | description       | author            |
| 1  | Change change 1@' | Test Description1 | Test Author1      |
| 1  | Aaa Bbb Ccc       | Change change 1@' | Test Author1      |
| 1  | Aaa Bbb Ccc       | Test Description1 | Change change 1@' |
| 1  | Change change 1@' | Change change 1@' | Change change 1@' |


@bug1 @bug7
Scenario Outline: Users can update a book parameter max characters
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
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


@bug8
Scenario: Users can skip passing parameter "Description" when updatding a book
	Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Author       |
		| 1  | Test Title1 | Test Author1 |
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


@bug1 @bug9
Scenario: Users can delete book's description
	Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
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


Scenario: Updating the details of non-existing book
	Given 'PUT' request to '/books/1' endpoint
	And Add request payload as JSON object:
		| Id | Title       | Description       | Author       |
		| 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |
	And Execute request
	Then Response code is '404'
	And Response is:
         | Message                   |
         | Book with id 1 not found! |

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		||

		
@noResponse @bug1
Scenario: Updating book details without specifying "Id"
	Given Following books in library:
        | Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |
	
	Given 'PUT' request to '/books' endpoint
	And Add request payload as JSON object:
		| Id | Title         | Description         | Author         |
		| 1  | Changed Title | Changed Description | Changed Author |
	And Execute request
	Then Response code is '405'

	Then 'GET' request to '/books' endpoint
	And Execute request
	Then Response code is '200'
	And Response is collection of:
		| Id | Title      | Description      | Author      |
        | 1  | Test Title | Test Description | Test Author |

		
@bug1 @bug4
Scenario Outline: Users cannot update a book if parameters' values exceed the maximum 
	Given Following books in library:
         | Id | Title       | Description       | Author       |
         | 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
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
		| Id | Title       | Description       | Author       |
		| 1  | Aaa Bbb Ccc | Test Description1 | Test Author1 |

Examples: 
| id | title                                                                                                 | author                          | message                                                                  |
| 0  | Test title                                                                                            | Test author                     | Book.Id should be a positive integer! Parameter name: book.Id            |
#title 101 chars
| 1  | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaZ | Test author                     | Book.Title should not exceed 100 characters! Parameter name: Book.Title  |
#author 31 chars
| 1  | Test title                                                                                            | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaZ | Book.Author should not exceed 30 characters! Parameter name: Book.Author |


@bug4 @bug6
Scenario Outline: Users cannot update a book without providing "Id", "Title" and "Author"
	Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
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
	Then Response code is '200'
	And Response is collection of:
		| Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

Examples: 
| property1 | property2   | property3   | property1_Value | property2_Value  | property3_Value  | message                                                                |
| Title     | Description | Author      | Test title      | Test Description | Test Author      | Book.Id should be a positive integer! Parameter name: book.Id          |
| Id        | Description | Author      | {int}1          | Test Description | Test Author      | Book.Title is a required field. Parameter name: book.Title             |
| Id        | Title       | Description | {int}1          | Test title       | Test Description | Book.Author is a required field. Parameter name: book.Author           |


@bug4 @bug6 @query6
Scenario Outline: Users cannot add book with invalid parameter values
	Given Following books in library:
        | Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

	When 'PUT' request to '/books/1' endpoint
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
	Then Response code is '200'
	And Response is collection of:
		| Id | Title       | Description       | Author       |
        | 1  | Test Title1 | Test Description1 | Test Author1 |

Examples: 
| id  | title      | description      | author      | message                                                       |
| one | Test Title | Test Description | Test Author | Book.Id should be a positive integer! Parameter name: book.Id |
| 1   | {int}123   | Test Description | Test Author | TBC                                                           |
| 1   | Test Title | {int}123         | Test Author | TBC                                                           |
| 1   | Test Title | Test Description | {int}123    | TBC                                                           |
| 1   | {int}123   | {int}456         | {int}789    | TBC                                                           |
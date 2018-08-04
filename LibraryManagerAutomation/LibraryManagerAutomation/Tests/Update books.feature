Feature: Update books
	In order to maintain books in a library
	As a API consumer
	I want to be able to send update books' details through endpoint


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


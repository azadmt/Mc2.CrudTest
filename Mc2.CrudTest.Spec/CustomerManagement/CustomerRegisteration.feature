Feature: CustomerRegisteration

@customer
Scenario: Register as new customer
	Given I want Register as a new customer
	When I register with following data
		| FirstName | LastName | EmailAddress     | PhoneNumber   | BankAccountNumber | DateOfBirth |
		| Mohammad  | Azad     | m.azad@gmail.com | +989127646102 | 465465465         | 2/5/1980    |
	Then I must be registered as new customer

Scenario: Register as new customer Whith Invalid PhoneNumber(PhoneNumber must be valid nation number)
	Given I want Register as a new customer
	When I register with following data
		| FirstName | LastName | EmailAddress     | PhoneNumber | BankAccountNumber | DateOfBirth |
		| Mohammad  | Azad     | m.azad@gmail.com | 9127646102  | 465465465         | 2/5/1980    |
	Then I must Get Invalid PhonNumber Error

Scenario: Register as new customer Whith Invalid EmailAddress
	Given I want Register as a new customer
	When I register with following data
		| FirstName | LastName | EmailAddress    | PhoneNumber   | BankAccountNumber | DateOfBirth |
		| Mohammad  | Azad     | m.azadgmail.com | +989127646102 | 465465465         | 2/5/1980    |
	Then I must Get Invalid EmailAddress Error
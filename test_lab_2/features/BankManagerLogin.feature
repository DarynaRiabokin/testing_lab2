Feature: Bank manager login

As a bank manager
I want to login as a bank manager

Scenario: Login
	Given I am on the Bank Manager login page
    When I login as a Bank Manager
    Then I should see the manager panel

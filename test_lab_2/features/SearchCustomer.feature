@Logined
Feature: Search Functionality of Bank Manager
  In order to manage customers effectively
  As a bank manager
  I want to use search functionality on the customer list page

Background:     
    Given I am on the customer search page
    And I have a full customer table information
    When I clear the search input
    Then I should see the full list of customers

  Scenario Outline: Successful search for an existing customer
    When I input in the search "<parameter>"
    Then I should see "<parameter>" in the search results
    Examples: 
              | parameter |
              | Hermoine  |
              | Potter    |
              | E55555    |
              | 1013      |

  Scenario: Unsuccessful search for a non-existent customer
    When  I input in the search "Unknown"
    Then I should see a empty table

  Scenario: Search with a single character
    When I input in the search "A"
    Then I should see all customers with names starting with "A"

  Scenario: Case insensitive search for a customer
    When I input in the search "poTTer"
    Then I should see "Potter" in the search results

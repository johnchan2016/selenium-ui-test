# Rink System (RMS)
- RMS has 2 modules: school (student registration) & boxOffice (ticket sales).

## For this UI test, 3 tests are created below:
  - Test 1: Simulate user login with different account
  ![Alt text](doc/test1/user-login.png?raw=true "Login Page")

  - Test 2: Simulate ticket purchase
  ![Alt text](doc/test2/user-login.png?raw=true "Open Session")
  ![Alt text](doc/test2/pick-a-ticket.png?raw=true "Pick a ticket")
  ![Alt text](doc/test2/purchase-success.png?raw=true "Purchase success")  

  - Test 3: Simulate to create a new class & schedule lessons for this class; if class is created, then remove lessons & re-create new lessons
  ![Alt text](doc/test3/create-new-class.png?raw=true "Creat new class")
  ![Alt text](doc/test3/create-lessons.png?raw=true "Create a new lesson")
  ![Alt text](doc/test3/create-class-n-lessons-success?raw=true "Create class & lessons success")

1. Page Object
  - Create component & page objects to manage maintenance code duplication & maintenance
  ![Alt text](doc/component-page-object.png?raw=true "Component & Page Object")

2. Test Report
  - Use ExtentReport library to create detailed reports for the tests
  ![Alt text](doc/extent-reports.png?raw=true "Extent Report")


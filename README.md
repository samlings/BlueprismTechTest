# BlueprismTechTest

This solution contains 4 projects:

- The console application: only contains the logic for validate user inputs, and creation of the DI container.
- A Services project that contains the domain logic and entities. This is the core of the application.
- An Infrastructure project that contains the implementation details for managing files.
- A Services.Tests that contains unit tests of the services library.


## Development Process

I started by implementing the domain logic. My approach was to create some unit tests and the logic around the requirement "where each word differs from the previous word by one letter only".
This was implemented on the FourLetterService class - the core logic of the application. Once done, I could then refactor and implement the rest of the application, 
such as dealing with file system (Infrastructure) or UI logic (console appliction).
I decided to keep the FourLetterService as clean as possible, for example by creating an immutable entity (class FourLetterWord) instead of dealing directly with strings.
I used Dependency Injection, which makes code loosely coupled and testable.
I also created a filter logic, in order to reduce the amount of words to the minimum when calling the FourLetterService.





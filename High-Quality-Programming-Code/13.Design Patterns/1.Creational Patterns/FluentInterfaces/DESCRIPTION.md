#Fluent Interface design

##1.Fluent Interface design pattern
+ Scenario of use: the fluent pattern is used to facilitate users of a library or class by predefining the order of initialialization, definition and execution of certain methods or steps 
+ Benefits:
  - allows method chaining
  - IntelliSense-friendly
  - serves to a certain extent as documentation, especially when IntelliSense is involved
  - defines order of methods that may otherwise be unclear
  - improves readability
  - improves consistency(when you need an object of a type, you use the factory)
  - facilitates the addition of new types

+ Drawbacks:
  - the cohesion goes to hell so that the user may have a more readable and pleasant experience
  - encapsulation is broken for the sake of method chaining
  - takes some planning
  - is not appropriate to use in every project, consider using it for libraries or classes that you wish to reuse
  - fluent interfaces are harder to debug
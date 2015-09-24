#Mediator Pattern

+ Scenario of use: The Mediator pattern is used when objects that need to interact should not know about each other. When the pattern is used correctly we are spared a total mess of dependencies and no other but the mediator know about the existence of all other objects that interact.

+ Benefits
	Promotes loose coupling
	Colleagues can be easily swapped out
	Limits subclassing

+ Drawbacks
	Mediator can become too complex if it handles not just communication between colleagues but logic too.

+ Diagram:

![Mediator pattern uml diagram](./Mediator.gif)

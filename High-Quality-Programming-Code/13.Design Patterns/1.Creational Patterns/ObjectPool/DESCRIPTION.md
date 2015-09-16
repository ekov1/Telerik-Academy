#Object Pool

##1.Object Pool design pattern
+ Scenario of use: The Object Pool design pattern is employed when creating objects is more expensive than cloning them or reusing them. When performance is key to the application OR when the end-user's device memory is scarce, Object Pool allocates only a set amount of objects, and juggles them whenever and however necessary 
+ Benefits:
  - objects are not destroyed, but instead reused, resulting in:
  	- improved performance
  	- improved memory use

+ Drawbacks:
  - there is a limit to the amount of objects the object pool can handle
  - when the limit of objects currently in use is reached, the pool should take responsibility and return a response to the user, notifying them of the situation, and/or throwing an exception, returning a null value;
  - weak cohesion
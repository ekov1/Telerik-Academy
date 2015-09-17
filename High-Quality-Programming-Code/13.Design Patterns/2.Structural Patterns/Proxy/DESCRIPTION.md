# Proxy

### Scenario of use:
    The Proxy object replaces an object, revealing the same interfaces as the object replaced, while also providing controlled access to its methods and properties 
    
### Benefits:
    Provides an extra level of indirection to support controlled access
	Proxy and the original object are interchangeable
	Can be lazily initialized
    
### Drawbacks:
    Client-side implementation of a proxy is pointless

![Proxy pattern](./Proxy.png)
    
### Real world example:
- [Proxy](./ChinaWebSurferProxy.cs) can be used to provide or restrict access to certain domains in a country.
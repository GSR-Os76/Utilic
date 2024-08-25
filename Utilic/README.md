﻿# Utilic

Assorted utilities library.

## Versioning

### Scheme

**W.X.Y.Z**

- W:
	- Increased by one after a complete rewrite redesign. 
	- Starts at one.
- X:
	- Increased by one after any revision in existing contract, or misadherence corrections that breakingly change signatures. 
	- Starts at zero.
- Y:
	- Increased by one after any expansion of existing contract. 
	- Starts at zero.
- Z:
	- Increased by one after fixing any misadherence to contract except those that're covered by **X**, fixing any typo, or improving documentation, as well as when making any other change to the flow of control even if it isn't outwardly detectable. 
	- Starts at zero.
	

### Practices
- A version number, (X, Y, Z), must increase once for every pull request, and only once.
- Increases to a higher number reset all lower numbers.
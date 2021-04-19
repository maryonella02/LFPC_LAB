# LFPC_LAB 3

Variant Nr 29

###### Initial form of the grammar:  

```c#
S -> aB
S -> DA
A -> BD
A -> a
A -> ADADB
B -> b
B -> ASB
D -> *
```

###### Step 1: Eliminate start symbol from the RHS( right hand side). If the start symbol S is at the right-hand side of any production, create a new production as:

```c#
S0 -> S
S -> aB
S -> DA
A -> BD
A -> a
A -> ADADB
B -> b
B -> ASB
D -> *
```

###### Step 2:  Eliminate terminals from the RHS of the production if they exist with other non-terminals or terminals. I will add Non-Terminals starting from G, in alphabetical order, as I did in the solution:

```c#
S0 -> S
S -> GB
S -> DA
A -> BD
A -> a
A -> ADADB
B -> b
B -> ASB
D -> *
G -> a
```

###### Step 3: Eliminate null productions:

```c#
S0 -> S
S -> GB
S -> DA
A -> BD
A -> a
A -> ADADB
B -> b
B -> ASB
G -> a
S -> A
A -> B
A -> AADB
A -> ADAB
A -> AAB
```

###### Step 4: Eliminate RHS with more than two non-terminals. This step can be repeated multiple times till all rules don't have more than two Non-Terminals on RHS:

```c#
S0 -> S
S -> GB
S -> DA
A -> BD
A -> a
B -> MB
B -> b
G -> IB
G -> a
S -> A
A -> B
A -> JK
H -> HL
H -> JB
H -> AD
I -> AS
J -> AA
K -> DB
L -> AB
M -> HH
```


###### Step 5: Eliminate unit productions: 
```c#
For S0 -> S
For S -> A
For S0 -> A
For S -> B
For S0 -> B
For A -> B
S -> GB
S -> DA
A -> BD
A -> a
B -> MB
B -> b
G -> IB
G -> a
A -> JK
H -> HL
H -> JB
H -> AD
I -> AS
J -> AA
K -> DB
L -> AB
M -> HH
S0 -> GB
S0 -> DA
S -> BD
S -> a
S -> JK
S0 -> BD
S0 -> a
S0 -> JK
S -> MB
S -> b
S0 -> MB
S0 -> b
A -> MB
A -> b
```

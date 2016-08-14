expression:
	expression "=" additive
	| expression "<" additive
	| expression ">" additive 
	| expression "<=" additive 
	| expression ">=" additive 
	| expression "!=" additive 
	| expression "<>" additive 
	| expression "*" additive 
	| expression "/" additive 
	| expression "+" additive 
	| expression "-" additive 
	| additive
	;
	
additive:
	ID '(' arglist ')'
	| '(' expression ')'
	| '[' elemlist ']'
	| '!' expression
	| '-' expression
	| NUMBER
	| ID
	;

arglist:
	expression | 
	arglist ',' expression
	;

elemlist:
	fqelement |
	elemlist ',' fqelement
	;
	
fqelement:
	element |
	element ':' element
	;

element:	
	'\'' ID '\'' |
	'"'	ID '"'
	;

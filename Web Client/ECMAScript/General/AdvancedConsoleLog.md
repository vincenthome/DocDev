ECMAScript
==========

console.log - Advanced Logging
----------------

```js
// output multiple data with different data types
console.log("MyString" , 123, { name: "vincent"});

// use %s for string, %d for digits etc...
console.log("String %s. Digits: %d");

// use %c to add CSS into the following text
console.log("Using CSS here %coutput", "color: red");

// Grouping
console.group[Collapsed]("myHeader");
	console.log("content ... ");
console.groundEnd();

// Internal maintained Counter
console.count("This happens n times!");

// Display time taken
console.time(key);
console.timeEnd(key);

// Display array in a table
console.table(myArray);
// select column to display
console.table(myArray, ["column1", "column2"]);
```

#Javascript Patterns Jump Start

[Basic JavaScript for the impatient programmer](http://www.2ality.com/2013/06/basic-javascript.html)

Supplement
* [5.4](http://stackoverflow.com/questions/5076944/what-is-the-difference-between-null-and-undefined-in-javascript)
    * undefined: a. declared but not initialized b. no declared at all
    * null: a value. object type.
* [5.5](http://adripofjavascript.com/blog/drips/javascripts-primitive-wrapper-objects.html)
    * Why primitive types has methods/properties?
    * 'xyz'.toUpperCase() : js implicitly created a temporary wrapper object. Once the method is called, the temporary object will be destroyed.
* [6.1]()
    * 6 falsy values: undefined, null, false, '', 0, NaN
* [6.2]
    * binary logical operators can returns non-boolean value
    * NaN && 'abc' returns NaN, 123 && 'abc' returns 'abc'
    * 'abc' || 123 returns 'abc', '' || 123 returns 123
* [10.1]
    * Function declaration/var declaration are hoisted
    * Function assignment IS NOT hoisted
* [10.3]
    * Function with too many arguments: additional arguments ... ignored
    * Function with too few arguments: missing arguments ... undefined
* [10.4]
    * Default value impl. pattern: x = x || 0; returns x if exists otherwise returns 0
* [10.5]
    * Enforce arity: if (arguments.length !== 2) { ... throw exception ... }
* [12](http://www.2ality.com/2011/01/javascripts-strict-mode-summary.html) What will cause strict mode errors
* [13.2] Variable declaration is hosited
* [13.3] A closure is a function plus the connection to the variables of its surrounding scopes.
* [13.4] IIFE (function () { ... }());
* [13.5] Unintended Sharing via closure
```javascript
var result = [];
    for (var i=0; i < 5; i++) {
        result.push(function () { return i });  // (*)
    }
    console.log(result[1]()); // 5 (not 1)
    console.log(result[3]()); // 5 (not 3)
```
* [13.6]
* [14.4] using 'this' in callback function. 'this' is associated with the caller. It could be anything.
```javascript
var jane = {
  name: 'Jane',
  friends: ['Tarzan', 'Cheeta'],
  logHiToFriends: function() {
    //var that = this; // to fix, use 'that'
    this.friends.forEach(function(friend) {
      console.log(this.name + ' says hi to ' + friend); // this becomes the window object, to fix use 'that'
    });
  }
};
```
* [14.5] Create Constructor and Shared Methods
```javascript
function Point(x, y) {
    this.x = x;
    this.y = y;
  }
  // Methods
Point.prototype.dist = function() {
  return Math.sqrt(this.x * this.x + this.y * this.y);
};
var p = new Point(3, 5);
p.x;
p.dist();
```
* [15.2] 
```javascript
var arr = ['a', 'b', 'c'];

1 in arr; // does arr have an element at index 1? true
5 in arr; // does arr have an element at index 5? false

arr.slice(1, 2); // copy elements ['b']
arr.slice(1); // ['b', 'c']

arr.push('x'); // append to last element arr['a', 'b', 'c', 'x']
arr.pop(); // remove last element arr['a', 'b', 'c']

arr.shift(); // remove first element arr['b', 'c']
arr.unshift('x'); // prepend first element arr['x', 'b', 'c']

arr.indexOf('b'); // find the index of an element 1

arr.join('-'); // all elements in a single string 'x-b-c'
arr.join(''); // 'xbc'
arr.join(); // 'x,b,c'

arr.forEach(
        function (elem, index) {
            console.log(index + '. ' + elem); // 0.a 1.b 2.c
        });
        
[1,2,3].map(function (x) { return x*x }) // map create a new array [ 1, 4, 9 ]
``` 
* [18 Date](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date) new Date();
* [18 JSON](http://www.2ality.com/2011/08/json-api.html)
    * JSON.stringify({ name : "mary", age : 13 }); // { "name" : "mary", "age" : 13 }
    * JSON.parse('{ "name" : "mary", "age" : 13 }'); // { name : "mary", age : 13 }
    
[Understanding the “this” keyword in JavaScript](http://toddmotto.com/understanding-the-this-keyword-in-javascript/)

[Mastering the Module Pattern](http://toddmotto.com/mastering-the-module-pattern/)

[Everything you wanted to know about JavaScript scope](http://toddmotto.com/everything-you-wanted-to-know-about-javascript-scope/)

[Style Guide ES5](https://github.com/airbnb/javascript/tree/master/es5)

[Style Guide ES6](https://github.com/airbnb/javascript)

[ES6](https://github.com/getify/You-Dont-Know-JS/blob/master/es6%20&%20beyond/README.md#you-dont-know-js-es6--beyond)

[Learning JavaScript Design Patterns](http://addyosmani.com/resources/essentialjsdesignpatterns/book/)


##Prototype Pattern

```javascript
//Class and Constructor function 
//Using var and anonymous function
//Using 'this' is REQUIRED
var Car = function (eng) {
    this.engine = eng;
};
//End of Class and ctor function

// Prototype using Object Literal. Using ':'
Car.prototype = {
    start: function() {
        alert('Car started engine ' + this.engine);
    },
        
    stop: function() {
        alert('Car stopped');
    }
};
//End of Prototype

//using it
Car myCar = new Car('V4');
```

##Revealing Module Pattern

###Singleton - Shared

```javascript
//Non-Class
//Using var on anonymous function
var car = function () {
    //private var properties, var functions using '='
    var engine,
    // Since not instatiate the car, use init instead.
    init = function(eng) {
        engine = eng;
    },
    start = function () {
        alert('Car started ' + engine);
    },
    stop = function () {
        alert('Car stopped');
    };

    //'Revealing Module - Object Literal' 
	//public members
    return {
        start: start,
        stop: stop
    };
}();
//End of anonymous function

// Using it.
car.init('V6')
car.start();
car.stop();
```

###Multiple Unique Instances

**Capitalize 'Car',  Self-invoked Parenthesis Removed**

```javascript
//Class
//Using var on anonymous Constructor function
//UPPER CASE 'Car'
//OR 1. add eng param to the ctor, 2. remove init
var Car = function () {
    
    // ... Everything else are the same as above
    
}; //Parenthesis Removed
//End of Class and ctor function

// Using it.
var myCar = new Car();
myCar.init('V6');
myCar.start();
myCar.stop();

// OR
var myCar = new Car('V6');
myCar.start();
myCar.stop();

```

##Revealing Prototype Pattern

```javascript
//Namespace - vehicle
var vehicle = vehicle || {};

//Class and Constructor function
//Using namespace+field and anonymous function
//Using 'this' is REQUIRED
vehicle.Car = function (eng) {
    this.engine = eng;
};
//End of Class and ctor function

//Prototype using anonymous function. NOTE: NOT Object Literal
//Self-Invoked
vehicle.Car.prototype = function () {
	//private var properties, var functions using '='
    var start = function () {
        alert('Car started ' + this.engine);
    },
    stop = function () {
        alert('Car stopped');
    };

    //public members
    return {
        start: start,
        stop: stop
    };
}();
//End of Prototype

//Using it
var myCar = new vehicle.Car('V8');
myCar.start();
myCar.stop();
```

##Prototype and Inheritance

###Base class

```javascript
var BaseCalculator = function () {       
    // unique to each instance of BaseCalculator       
    this.decimalDigits = 2; 
}; 
BaseCalculator.prototype = {       
    // private members       
    add: function (x, y) {               
    return x + y;       
    },       
    subtract: function (x, y) {               
        return x - y;       
    } 
};
```

###Derived class

```javascript
// Create a Derived class
var Calculator = function () {       
    // Define a variable unique to       
    // each instance of Calculator       
    this.tax = 5; 
}; 

Calculator.prototype = new BaseCalculator();

// Using it
var calc = new Calculator(); 
alert( calc.add( 1, 1)); 
// Variable defined in the BaseCalculator 
// parent object is accessible from 
// the derived Calculator object's constructor 
alert( calc.decimalDigits);
```

###Override Prototype method

```javascript
// Override Calculator's add() function 
Calculator.prototype.add = function (x, y) {       
    return x + y + this.tax; 
};
```

###Disable Prototype variable

```javascript
//Because the BaseCalcuator's prototype is assigned directly to Calculator's prototype, 
// the decimalDigits variable defined in BaseCalculator will no longer be accessible
Calculator.prototype = BaseCalculator.prototype;

// Using it
var calc = new Calculator(); 
// this will throw a javascript exception!
alert( calc.decimalDigits);


```
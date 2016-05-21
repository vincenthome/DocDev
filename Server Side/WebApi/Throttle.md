# WebApiThrottle

ASP.NET Web API Throttling handler, OWIN middleware and filter are designed to control the rate of requests that clients can make to a Web API based on IP address, client API key and request route.

Web API throttling can be configured using the built-in ThrottlePolicy. You can set multiple limits for different scenarios like allowing an IP or Client to make a maximum number of calls per second, per minute, per hour per day or even per week. You can define these limits to address all requests made to an API or you can scope the limits to each API route.

[https://github.com/stefanprodan/WebApiThrottle](https://github.com/stefanprodan/WebApiThrottle)
# Introduction

The goal of the current challenge is to check an ability to read the code and write simple unit tests.

# The challenge

There are three levels of difficulty:
1. **Easy**: `Task1`, you already have the test that is almost ready for execution. So, it is good place to start.
2. **Medium**: `Task2`, you already have the object, however there is no methods defined that you need to test. Try to think and select appropriate one.
3. **Hard**: `Task3`, you have the service to test called `CalendarEventFactory`, hovewer you have no input data and strategy to test, try use the knowledge you get from previous steps to address the issue.

# Code functionality description

The whole idea about this piece of code is to build the events from availability slots. 
Imagine the following use-case:
1. There is an Availability slot created from 1st of October to 21th of October. We need to have events each Monday, Tuesday, and Friday. 
2. However, we need to skip several events (status = deleted, and recurrentId equals the root event) during the second week. 
3. In total we will get 6 (out of 9) events after the execution.

We the main code is located inside `CalendarEventFactory`, the rest of parts located inside `Recurrence`. Please take your time to investigate, and find the way how to cover the code by unit tests. 

# Useful links
1. https://www.meziantou.net/quick-introduction-to-xunitdotnet.htm

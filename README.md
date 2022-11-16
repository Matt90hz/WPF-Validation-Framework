# WPF Validation Framework

## Why I build this project?
I was working on a project with a number of models. When the time to add validation come it felt awkward mark every model with attribute or even worse insert validation directly in the model.
I wanted a way to describe te validation for a model without touching the model itself.

## What the project does?
It abstracts the validation of the properties of an object using a separate class (IValidationDescriptions<T>) based on the type of the object.

## How to use the project
ValidationService is a facade class for validation, use it to register IValidationDescriptions<T> where T is the object that you want to validate.
The simplest way of doing so is inherit form the abstract class ValidationDescriptions<T> and in the constructor add the rules via RulesFor and AddRule methods.

Look at the Example project inside the git to see the framework in action, https://github.com/Matt90hz/WPF-Validation-Framework.

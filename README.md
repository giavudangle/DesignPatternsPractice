 ## Gang of Four Book Ecommerce 🚀


<div >
<img width="400px" height="400px" src="https://res.cloudinary.com/codingwithvudang/image/upload/v1622117732/logo_hcbfie.png" >


## 🚀 Patterns Applied (12 patterns)
1. Frontend React Native
  - [X] Singleton : In core/Singleton
  - [X] Factory : In core/Factory
  - [X] Template Method : In core/TemplateComposition 
  - [X] Composition : In core/TemplateComposition 
  - [X] Iterator : In core/Iterator
  - [X] Proxy: In core/Proxy
  - [X] Strategy : In core/Strategy
  - [X] Command : In core/Command
2. Backend Express API
  - [X] Singleton : In core/Facade
  - [X] Facade : In core/Facade
  - [X] Builder : In core/Builder
  - [X] Prototype : In core/Prototype
  - [X] Observer : In core/Observer
3. Frameworks/Libraries:
  - [X] Chain of Responsibility : Using Redux for state management
  - [X] Composition: React Native follow React's strategy 
    In React using Composition and Props gives you all the flexibility that you would need. React does not say Composition is better than Inheritance. Composition just fits better within the React’s component structure.
   - [X] Chain Of Responsibility : có thể thấy ở các middleware, sự chuyển tiếp của request đến một middleware nào đó để xử lý ( ví dụ upload image, resize ảnh, lấy token…) là một chuỗi các sự việc liên tiếp được vận chuyển qua các tầng khác nhau để xử lý.
   - [X] Factory : khi chúng ta khởi tạo const App = express() thực chất bên trong lõi function của express đang thực thi function createApplication() và nó chính là AppFactory.
   - [X] Decorator : request và response đơn thuần của HTTP rất ít tính năng, bản thân express đã decorate thêm nhiều thứ để tăng cường độ phủ của các tính năng mà bản thân 1 http không có. Có thể kể đến như      if (app.enabled('x-powered-by')) res.setHeader('X-Powered-By', 'Express');
   - [X] Strategy : Express khi dùng với web MVC, hỗ trợ rất nhiều template engine : ejs, pub, swig. Nó thể hiện qua việc sử dụng app.engine('.html', exphbs({...}));
   - [X] Proxy : Ứng dụng trong việc protect các middleware ở các tầng khác nhau. Với express ta có 2 tầng middlewarea là :  Application-level middleware, Router-level middleware -> caseSensitive: this.enabled('case sensitive routing').
   - [X] Observer : Mẫu này thường dùng để bắt các event để tiến hành phản hồi có thể thấy server.listen(3000, '127.0.0.1', () => {
     console.log('Server up and running');
   }); chính là cách áp dụng Observer.


## 🚀 Gang of Four Design Patterns
Design Patterns: Elements of Reusable Object-Oriented Software is a book on software engineering highlighting the capabilities and pitfalls of object-oriented programming. They have listed down 23 classic software design patterns which are influential even in the current software development environment. The authors are often referred to as the Gang of Four (GoF).

1. Creational Patterns
  - Singleton
  - Factory
  - Abstract Factory
  - Builder
  - Prototype
2. Structural Patterns
  - Adapter
  - Composite
  - Proxy
  - Flyweight
  - Facade
  - Bridge
  - Decorator
3. Behavioral Patterns
  - Template Method
  - Mediator
  - Chain of Responsibility
  - Observer
  - Strategy
  - Command
  - State
  - Visitor
  - Iterator
  - Interpreter
  - Memento



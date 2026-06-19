# Controller
Là một lớp thừa kế Controller chứa các hàm action method và được tạo ra mỗi khi gửi request.  
Có thể truyền tham số vào để khởi tạo thông DI
### Some type results
1. ViewResult - Represents HTML and markup.
2. EmptyResult - Represents no result.
3. RedirectResult - Represents a redirection to a new URL.
4. JsonResult - Represents a JavaScript Object Notation result that can be used in an AJAX application.
5. JavaScriptResult - Represents a JavaScript script.
6. ContentResult - Represents a text result.
7. FileContentResult - Represents a downloadable file (with the binary content).
8. FilePathResult - Represents a downloadable file (with a path).
9. FileStreamResult - Represents a downloadable file (with a file stream).
---
### Differences between AddTransient, AddScoped, AddSingleton
- Transient objects are always different; a new instance is provided to every controller and every service.

- Scoped objects are the same within a request, but different across different requests.

- Singleton objects are the same for every object and every request.
---
### The Related Documents
1. https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs  
2. https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
3. https://medium.com/@developerstory/addsingleton-vs-addtransient-vs-addscoped-in-net-core-9a936147c72e
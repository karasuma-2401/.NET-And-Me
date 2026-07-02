# Some attribute need to know
### Non Action
- Chỉ ra một hàm không phải action method == không được map vào URL

### Non controller
- Chỉ ra một lớp không phải controller => tất cả các hàm không thể được gọi thông qua URL.
- Ngoài còn có thể tính kế thừa => tất cả các lớp kế thừa lớp sở hữu thuộc tính ngày của sẽ khiến tất các hàm bên trong đ không thể được gọi thông qua controller

### HTTP
- Dùng để chỉ định một HTTP method được dùng cho action request
- Có thể sử dụng kết hợp với nhau

### From
- Chỉ định nguồn dữ liệu để lấy về giá trị cho một tham số của một action medthod

### Route
- Chỉ ra URL để ánh xa theo các action method

---

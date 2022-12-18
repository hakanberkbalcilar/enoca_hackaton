karsav-hackathon

### Create User : POST: /api/Users/
```
{
  "name": "string",
  "surname": "string",
  "email": "string",
  "password": "string"
}
```

### Create Token : POST : /api/Users/Connect/Token/
```
{
  "email": "hakanberkbalcilar@gmail.com",
  "password": "4780h64h"
}
```

### Refresh Token : GET: /api/Users/RefreshToken?refreshToken={token}
```
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ByaW1hcnlzaWQiOiIxIiwibmJmIjoxNjcxMzMwNTQ5LCJleHAiOjE2NzEzMzE0NDksImlzcyI6Ind3dy5oYWNrYXRvbi5jb20iLCJhdWQiOiJ3d3cuaGFja2F0b24uY29tIn0.DRXS-o_Zx7AEjb4xsKH4-Tx67PJgeUX6R_lBuyQY0wE",
  "expireDate": "2022-12-18T05:44:09.213691+03:00",
  "refreshToken": "1644f099-1316-4d12-b10e-69efdfb32a3f"
}
```

### Get Companies : GET: /api/Companies/
```
[
  {
    "id": 1,
    "name": "TestCompany",
    "orderStart": {
      "hour": 8,
      "minute": 0
    },
    "orderEnd": {
      "hour": 23,
      "minute": 59
    },
    "status": true
  }
]
```

### Create Company : POST: /api/Companies/
```
{
  "name": "CompanyName",
  "orderStart": {
    "hour": 23,
    "minute": 59
  },
  "orderEnd": {
    "hour": 23,
    "minute": 59
  },
  "status": true
}
```

### Update Company : PUT: /api/Companies/{id}
```
{
  "orderStart": {
    "hour": 23,
    "minute": 59
  },
  "orderEnd": {
    "hour": 23,
    "minute": 59
  },
  "status": true
}
```


### Get Products : GET: /api/Products/
```
[
  {
    "id": 1,
    "companyId": 1,
    "name": "TestProduct",
    "amount": 15,
    "price": 125
  }
]
```

### Create Product : POST : /api/Products/
```
{
  "companyId": 0,
  "name": "string",
  "amount": 0,
  "price": 0
}
```

### Update Product : PUT: /api/Products/{id}
```
{
  "name": "string",
  "amount": 0,
  "price": 0
}
```

### Create Order : POST : /api/Orders/
```
{
  "companyId": 0,
  "productId": 0,
  "customerName": "string",
  "date": "2022-12-18T02:25:01.166Z"
}
```

config.json

```json
{
    "ConnectionStrings": {
        "DbConnection": "Server=___;Database=___;User Id=___;Password=___;"
    }
}
```

<!-- {
    "DbConnection": {
        "server": "",
        "database": "",
        "userId": "",
        "password": ""
    }
} -->

## Run in VS

```shell
dotnet new sln -n vssolution
```


```shell
dotnet sln vssolution.sln add package.csproj
```